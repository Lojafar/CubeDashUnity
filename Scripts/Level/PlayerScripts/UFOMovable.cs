using UnityEngine;

public class UFOMovable : MovableBase
{
    const float jumpDelay = 0.15f;
    float remainingJumpDelay = 0;
    float NeededRotZ = 0;

    const  float rotationSpeed = 2.5f;
    public UFOMovable(Player pl) : base(pl, 17)
    {
        CanJump = true;
    }
    public override void OnStartUsing()
    {
        player.SkinChanger.SetNewSkin(SkinType.UFOSkin);
    }
    public override void OnFinishUsing()
    {
        player.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    public override void Move()
    {
        TryJump();
        rotateIfNeecessary();
        if (player.rb.velocity.y < 0) { 
            NeededRotZ = 0;
        }
        player.rb.velocity = new Vector2(player.Speed, player.rb.velocity.y);
    }
    void rotateIfNeecessary()
    {
        if (Mathf.FloorToInt(player.transform.rotation.eulerAngles.z) != Mathf.FloorToInt(NeededRotZ))
        {
            player.transform.eulerAngles = Vector3.RotateTowards(player.transform.eulerAngles, new Vector3(player.transform.eulerAngles.x, player.transform.eulerAngles.y, NeededRotZ ), rotationSpeed, 1);
        }
    }
    public override void TryJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (remainingJumpDelay <= 0)
            {
                remainingJumpDelay = jumpDelay;
                Jump();
            }
        }
        remainingJumpDelay -= Time.deltaTime;
    }
    public override void Jump(float JumpForceMod = 1)
    {
        NeededRotZ = 15;
        player.transform.eulerAngles = new Vector3(player.transform.eulerAngles.x, player.transform.eulerAngles.y, 20) ;
        player.rb.velocity = new Vector2(player.rb.velocity.x, JumpForce * JumpForceMod);
        CanJump = false;
        
    }
    public override void OnCollionEnt(Collision2D collision)
    {
        player.transform.rotation = Quaternion.Euler(0, 0, 0);
        base.OnCollionEnt(collision);

    }
}
