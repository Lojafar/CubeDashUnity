using System;
using System.Collections.Generic;
using UnityEngine;

public class GameSavesController : MonoBehaviour
{
    ISaverLoader saverLoader;
    public static GameSavesController instance;
    public GameSaves GameSaves { get; private set; }
    public const string version = "1.0.0.0";
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            saverLoader = new TestSaverLoader();
        }
        else Destroy(gameObject);
    }
    private void Start()
    {
        LoadSaves();
    }
    void LoadSaves()
    {
        GameSaves loadedGameSaves = saverLoader.LoadSaves();

        if (loadedGameSaves.LevelsProgresses == null || loadedGameSaves.LevelsProgresses.Length == 0)
        {
            loadedGameSaves.LevelsProgresses = new int[GameContainer.Instance.LevelsCount];
        }
        if (loadedGameSaves.LevelsProgresses.Length != GameContainer.Instance.LevelsCount)
        {
            int[] progresses = loadedGameSaves.LevelsProgresses;
            loadedGameSaves.LevelsProgresses = new int[GameContainer.Instance.LevelsCount];
            progresses.CopyTo(loadedGameSaves.LevelsProgresses, 0);
        }
        if (loadedGameSaves.Purchasings == null)
        {
            loadedGameSaves.Purchasings = new Dictionary<SkinType, bool[]>();
            loadedGameSaves.ActiveSkins = new Dictionary<SkinType, int>();

            loadedGameSaves.SkinColorNumber1 = 1;
            loadedGameSaves.SkinColorNumber2 = 2;
        }
        for (int i = 0; i < Enum.GetNames(typeof(SkinType)).Length; i++)
        {
            if (loadedGameSaves.Purchasings.ContainsKey((SkinType)i)) continue;
            SkinType skinType = (SkinType)i;
            int SkinsArrayLength = GameContainer.Instance.GetSkinsListByType(skinType).Skins.Length;
            loadedGameSaves.Purchasings.Add(skinType, new bool[SkinsArrayLength]);
            loadedGameSaves.Purchasings[(SkinType)i][0] = true;
            loadedGameSaves.ActiveSkins.Add(skinType, 0); 
        }
        

        GameSaves = loadedGameSaves;
    }
    public void ClearSaves()
    {
        saverLoader.ClearAllSaves();
        LoadSaves();
    }
    public void Save()
    {
        saverLoader.Save(GameSaves);
    }
    
}
