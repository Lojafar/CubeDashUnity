using UnityEngine;

public class CubeMovable : MovableBase
{
    float NeededRotZ;
    const float jumpDelay = 0.08f;
    float remainingJumpDelay = 0;
    bool  isJumping ;

    const float rotationSpeed = 2.5f;
    public CubeMovable(Player pl) : base(pl, 14) { }
    public override void OnStartUsing()
    {
        player.SkinChanger.SetNewSkin(SkinType.CubeSkin);
        player.rb.velocity = new Vector2(player.Speed, player.rb.velocity.y);
        NeededRotZ = 0;
    }
    public override void OnFinishUsing()
    {
        player.DashParticles.gameObject.SetActive(false);
        player.PlayerTransform.rotation = Quaternion.Euler(0, 0, 0);
    }
    public override void Move()
    {
        TryJump();
        rotateIfNeecessary();
        CanJump = CheckGround();
        player.rb.velocity = new Vector2(player.Speed, player.rb.velocity.y);
    }
    public override void TryJump()
    {
        if(Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            if(remainingJumpDelay <= 0 && CanJump)
            {
                remainingJumpDelay = jumpDelay;
                Jump();
            }
        }
        remainingJumpDelay -= Time.deltaTime;
    }
    void rotateIfNeecessary()
    {
        if (Mathf.FloorToInt(player.PlayerTransform.rotation.eulerAngles.z) != Mathf.FloorToInt(NeededRotZ))
        {
            player.PlayerTransform.Rotate(new Vector3(player.PlayerTransform.rotation.eulerAngles.x, player.PlayerTransform.rotation.eulerAngles.y, NeededRotZ * Time.deltaTime), rotationSpeed);
        }
    }
    bool CheckGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(player.PlayerTransform.position - new Vector3(0, 0.5f, 0), -Vector2.up, 0.2f);
        if (hit.collider != null  && hit.collider.tag == "Ground")
        {
            return true;
        }
        return false;
    }
    public override void Jump(float JumpForceMod = 1)
    {
        CanJump = false;
        isJumping = true;
        player.rb.velocity = new Vector2(player.rb.velocity.x, JumpForce * JumpForceMod);
        NeededRotZ = Mathf.RoundToInt((player.PlayerTransform.rotation.eulerAngles.z - 1) / 90) * 90 + 90;
        if (NeededRotZ >= 360) NeededRotZ -= 359.9f;
    }

    public override void OnCollionEnt(Collision2D collision)
    {
        isJumping = false;
        if (collision.gameObject.tag == "Ground")
        {
            player.DashParticles.gameObject.SetActive(true);
        }
        base.OnCollionEnt(collision);
    }
    public override void OnCollionExt(Collision2D collision)
    {
        player.DashParticles.gameObject.SetActive(false);
    }
}