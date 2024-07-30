using UnityEngine;

public class GameContainer : MonoBehaviour
{
    [SerializeField] LevelItem[] levelsItems;
    [SerializeField] SkinsListScriptObj cubeSkins;
    [SerializeField] SkinsListScriptObj arrowSkins;
    [SerializeField] SkinsListScriptObj ufoSkins;
    [SerializeField] SkinsListScriptObj shipSkins;
    [SerializeField] ColorsListScriptObj colorsListSO;
    public  SkinsListScriptObj CubeSkins => cubeSkins;
    public SkinsListScriptObj ArrowSkins => arrowSkins;
    public SkinsListScriptObj UFOSkins => arrowSkins;
    public SkinsListScriptObj ShipSkins => arrowSkins;
    public ColorsListScriptObj ColorListSO => colorsListSO;

    public int LevelsCount => levelsItems.Length;
    public int CurrentLevelIndex = 0;

    public static GameContainer Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        PortalsCollection.Initialize();
        ExtraEffectsCollection.Initialize();
    }
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    public LevelItem GetLevelItemByIndex(int levelIndex)
    {
        if(LevelsCount == 0)
        {
            Debug.LogError("Levels Array is not setted");
            return null;
        }
        if (levelIndex < 0 || levelIndex >= LevelsCount)
        {
            Debug.LogError("Level index cannot be less than 0 or greater than the size of the array. Level index is: " + levelIndex);
            return levelsItems[0];
        }
        else
        {
            return levelsItems[levelIndex];
        }
    }
    public  SkinsListScriptObj GetSkinsListByType(SkinType skinType)
    {
        switch (skinType)
        {
            case SkinType.CubeSkin:
                return cubeSkins;
            case SkinType.ArrowSkin:
                return arrowSkins;
            case SkinType.UFOSkin:
                return ufoSkins;
            case SkinType.ShipSkin:
                return shipSkins;
        }
        Debug.LogError("SkinList not setted. SkinType: " + skinType);
        return cubeSkins;
    }
}
