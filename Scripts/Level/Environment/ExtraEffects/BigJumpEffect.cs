

public class BigJumpEffect : IExtraEffect
{
    public void Use(Player player)
    {
        player.CurrentMovable.Jump(1.5f);
    }
}
