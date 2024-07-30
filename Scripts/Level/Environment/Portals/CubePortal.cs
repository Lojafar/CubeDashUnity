public class CubePortal : IPortal
{
    public void OnPlayerEnter(Player player)
    {
        player.SetNewMovableState(typeof(CubeMovable));
    }
}
