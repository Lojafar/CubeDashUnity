
public class TestSaverLoader : ISaverLoader
{
    public void ClearAllSaves()
    {
    }

    public GameSaves LoadSaves()
    {
            return new GameSaves();
    }

    public void Save(GameSaves gameSaves)
    {
    }
}

