using System;
public static class PortalsCollection
{
    static IPortal[] AllPortalsCache;

    public static void Initialize()
    {
        int PortalsCount = Enum.GetNames(typeof(PortalType)).Length + 1;
        AllPortalsCache = new IPortal[PortalsCount];

        for (int i = 0; i < PortalsCount; i++)
        {
            IPortal portal = GetPortalByType((PortalType)i);
            AllPortalsCache[i] = portal;
        }
    }
    public static IPortal GetPortalCache(PortalType portalType)
    {
        return AllPortalsCache[(int)portalType];
    }
    static IPortal GetPortalByType(PortalType portalType)
    {
        switch (portalType)
        {
            case PortalType.ShipPortal: return new ShipPortal();
            case PortalType.CubePortal: return new CubePortal();
            case PortalType.ArrowPortal: return new ArrowPortal();
            case PortalType.UFOPortal: return new UFOPortal();
        }
        return new ShipPortal();
    }
}
