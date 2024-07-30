public interface ISaverLoader 
{
    public void Save(GameSaves gameSaves);
    public void ClearAllSaves();
    GameSaves LoadSaves();
}
