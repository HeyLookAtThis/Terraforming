public class MainSpawner
{
    private CoinsSpawner _coinsSpawner;
    private TreeSpawner _treeSpawner;
    private VolcanoSpawner _volcanoSpawner;
    private SnowflakeSpawner _snowflakeSpawner;

    public MainSpawner(MainStorage mainStorage, LevelBordersMarker marker, LevelCounter levelCounter)
    {
        _coinsSpawner = new CoinsSpawner(marker, levelCounter, mainStorage.Coins);
        _treeSpawner = new TreeSpawner(marker, levelCounter, mainStorage.Trees);
        _volcanoSpawner = new VolcanoSpawner(marker, levelCounter, mainStorage.Volcanoes);
        _snowflakeSpawner = new SnowflakeSpawner(mainStorage.Snowflakes, mainStorage.Trees, marker);
    }

    public void Run()
    {
        _coinsSpawner.Run();
        _treeSpawner.Run();
        _volcanoSpawner.Run();
        _snowflakeSpawner.Run();
    }
}
