using UnityEngine;

public abstract class MovableBase
{
    public Player player { get; private set; }
    public float JumpForce { get; private set; }
    public bool CanJump;

    public MovableBase(Player player, float jumpForce)
    {
        this.player = player;
        JumpForce = jumpForce;
    }
    public abstract void OnStartUsing();
    public abstract void OnFinishUsing();
    public abstract void Move();
    public abstract void TryJump();
    public abstract void Jump(float JumpForceMod = 1);
    public virtual void OnCollionEnt(Collision2D collision){ }
    public virtual void OnCollionExt(Collision2D collision) { }
}
