using UnityEngine;

public class ShipMovable : MovableBase
{
    float NeededRotZ;
    bool isFalling;
    bool isCollised;
    float jumpAcceleration;

    const float rotationSpeed = 1;
    public ShipMovable(Player pl) : base(pl, 5)
    {}
    public override void OnStartUsing()
    {
        player.SkinChanger.SetNewSkin(SkinType.ShipSkin);
        NeededRotZ = 0;
    }
    public override void OnFinishUsing()
    {
        player.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    public override void Move()
    {
        TryJump();
        CheckFalling();
        rotateIfNeecessary();
        player.rb.velocity = new Vector2(player.Speed, player.rb.velocity.y);
       
    }
    void CheckFalling()
    {
        if (player.rb.velocity.y < 0)
        {
            if (!isFalling)
            {
                jumpAcceleration = 0;
                isFalling = true;
                NeededRotZ = -25;
            }
        }
    }
    void rotateIfNeecessary()
    {
        if (Mathf.FloorToInt(player.transform.rotation.eulerAngles.z) != Mathf.FloorToInt(NeededRotZ))
        {
            if (isFalling && Mathf.FloorToInt(player.transform.rotation.eulerAngles.z) == 335) return;
            player.transform.Rotate(new Vector3(player.transform.rotation.eulerAngles.x, player.transform.rotation.eulerAngles.y, NeededRotZ * Time.deltaTime), rotationSpeed);
        }
    }
    public override void TryJump()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
              Jump();
        }
    }
    public override void Jump(float JumpForceMod = 1)
    {
        jumpAcceleration += 0.1f;
        player.rb.velocity = new Vector2(player.rb.velocity.x, JumpForce * JumpForceMod + jumpAcceleration);
        isFalling = false;
        if(!isCollised)
        NeededRotZ = 25;
    }
    public override void OnCollionEnt(Collision2D collision)
    {
        isCollised = true;
        player.transform.rotation = Quaternion.Euler(0, 0, 0);
        NeededRotZ = 0;
    }
    public override void OnCollionExt(Collision2D collision)
    {
        jumpAcceleration = 0;
        isCollised = false;
    }
}
