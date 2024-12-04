public class MainSpawner
{
    private MainFactory _mainFactory;
    private LevelBoundariesMarker _marker;

    private CoinsSpawner _coinsSpawner;
    private TreeSpawner _treeSpawner;

    public MainSpawner(MainFactory mainFactory, LevelBoundariesMarker marker)
    {
        _mainFactory = mainFactory;
        _marker = marker;
        _coinsSpawner = new CoinsSpawner(mainFactory.Coins, _marker);
        _treeSpawner = new TreeSpawner(mainFactory.Trees, _marker);
    }

    public void Run()
    {
        _coinsSpawner.Run();
        _treeSpawner.Run();
    }
}
