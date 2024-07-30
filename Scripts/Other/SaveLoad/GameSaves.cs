using System.Collections.Generic;
public class GameSaves
{
    public bool IsSoundOn = true;
    public int[] LevelsProgresses;
    public Dictionary<SkinType, bool[]> Purchasings = null;
    public Dictionary<SkinType, int> ActiveSkins = null;
    public int SkinColorNumber1, SkinColorNumber2;
    public GameSaves(){}
}
