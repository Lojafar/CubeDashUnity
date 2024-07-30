
public class ArrowPortal : IPortal
{
    public void OnPlayerEnter(Player player)
    {
        player.SetNewMovableState(typeof(ArrowMovable));
    }
}
