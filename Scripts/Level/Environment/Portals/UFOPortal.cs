public class UFOPortal : IPortal
{
    public void OnPlayerEnter(Player player)
    {
        player.SetNewMovableState(typeof(UFOMovable));
    }
}
