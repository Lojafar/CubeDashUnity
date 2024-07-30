using UnityEngine;

public class ArrowMovable : MovableBase
{
    float GravityBeforeUsing;
    const float jumpDelay = 0.1f;
    float remainingJumpDelay = 0;
    bool isFalling;
    bool collised;
    public ArrowMovable(Player pl) : base(pl, 10)
    {
        CanJump = true;
    }
    public override void OnStartUsing()
    {
        isFalling = false;
        player.SkinChanger.SetNewSkin(SkinType.ArrowSkin);
        player.BackTrail.gameObject.SetActive(true);
        player.BackTrail.Clear();
        GravityBeforeUsing = player.rb.gravityScale;
        player.rb.gravityScale = JumpForce / 2;
    }
    public override void OnFinishUsing()
    {
        player.BackTrail.gameObject.SetActive(false);
        player.transform.rotation = Quaternion.Euler(0, 0, 0);
        player.rb.gravityScale = GravityBeforeUsing;
    }
    public override void Move()
    {
        TryJump();
        CheckFalling();
        player.rb.velocity = new Vector2(player.Speed, player.rb.velocity.y);
    }
    public override void TryJump()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            if (remainingJumpDelay <= 0)
            {
                remainingJumpDelay = jumpDelay;
                Jump(1);
            }
        }
        remainingJumpDelay -= Time.deltaTime;
    }
    public override void Jump(float JumpForceMod = 1)
    {
        player.rb.velocity = new Vector2(player.rb.velocity.x, JumpForce * JumpForceMod);
        player.transform.rotation = Quaternion.Euler(0, 0, 25);
        isFalling = false;
    }
    void CheckFalling()
    {
        if (player.rb.velocity.y < JumpForce / 2) player.rb.velocity = new Vector2(player.Speed, -JumpForce / 2);
        if (player.rb.velocity.y < 0)
        {
            if(!collised) player.transform.rotation = Quaternion.Euler(0, 0, -25);
            if (!isFalling)
            {
                isFalling = true;
            }
        }
    }
    public override void OnCollionEnt(Collision2D collision)
    {
        collised = true;
        player.transform.rotation = Quaternion.Euler(0, 0, 0);
        base.OnCollionEnt(collision);
    }
    public override void OnCollionExt(Collision2D collision)
    {
        collised = false;
        base.OnCollionExt(collision);
    }

}