public class ShipPortal : IPortal
{
    public void OnPlayerEnter(Player player)
    {
        player.SetNewMovableState(typeof(ShipMovable));
    }
}
