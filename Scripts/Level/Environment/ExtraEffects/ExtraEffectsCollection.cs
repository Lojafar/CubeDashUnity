using System;
public static class ExtraEffectsCollection
{
    static IExtraEffect[] AllExtraEffectsCache;

    public static void Initialize()
    {
        int PortalsCount = Enum.GetNames(typeof(ExtraEffectType)).Length + 1;
        AllExtraEffectsCache = new IExtraEffect[PortalsCount];

        for (int i = 0; i < PortalsCount; i++)
        {
            IExtraEffect portal = GetExtraEffectBYType((ExtraEffectType)i);
            AllExtraEffectsCache[i] = portal;
        }
    }
    public static IExtraEffect GetExtraEffectCache(ExtraEffectType portalType)
    {
        return AllExtraEffectsCache[(int)portalType];
    }
    static IExtraEffect GetExtraEffectBYType(ExtraEffectType portalType)
    {
        switch (portalType)
        {
            case ExtraEffectType.BigJumpEffect: return new BigJumpEffect();
        }
        return new BigJumpEffect();
    }
}
