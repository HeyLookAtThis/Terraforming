public class MainSpawner
{
    private CoinsSpawner _coinsSpawner;
    private TreeSpawner _treeSpawner;
    private VolcanoSpawner _volcanoSpawner;
    private SnowflakeSpawner _snowflakeSpawner;

    private CircleCoordinateSystem _cellsSystem;

    public MainSpawner(MainStorage mainStorage, LevelBordersMarker marker, LevelCounter levelCounter)
    {
        _cellsSystem = new CircleCoordinateSystem(marker);

        _coinsSpawner = new CoinsSpawner(marker, levelCounter, mainStorage.Coins);
        _treeSpawner = new TreeSpawner(marker, levelCounter, mainStorage.Trees, _cellsSystem);
        _volcanoSpawner = new VolcanoSpawner(marker, levelCounter, mainStorage.Volcanoes, _cellsSystem);
        _snowflakeSpawner = new SnowflakeSpawner(mainStorage.Snowflakes, mainStorage.Trees, marker);
    }

    public void Run()
    {
        _coinsSpawner.Run();
        _treeSpawner.Run();
        _volcanoSpawner.Run();
        //_snowflakeSpawner.Run();
    }
}
