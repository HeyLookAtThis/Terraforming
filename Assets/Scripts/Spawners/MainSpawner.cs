public class MainSpawner
{
    private CoinsSpawner _coinsSpawner;
    private TreeSpawner _treeSpawner;
    private VolcanoSpawner _volcanoSpawner;
    private SnowflakeSpawner _snowflakeSpawner;

    public MainSpawner(MainFactory mainFactory, LevelBoundariesMarker marker)
    {
        _coinsSpawner = new CoinsSpawner(mainFactory.Coins, marker);
        _treeSpawner = new TreeSpawner(mainFactory.Trees, marker);
        _volcanoSpawner = new VolcanoSpawner(mainFactory.Volcanoes, marker);
        _snowflakeSpawner = new SnowflakeSpawner(mainFactory.Snowflakes, _treeSpawner, marker);
    }

    public void Run()
    {
        _coinsSpawner.Run();
        _treeSpawner.Run();
        _volcanoSpawner.Run();
        _snowflakeSpawner.Run();
    }

    public void Clear()
    {

    }
}
