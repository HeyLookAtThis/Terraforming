using UnityEngine;

public class MainSpawner
{
    private CoinsSpawner _coinsSpawner;
    private TreeSpawner _treeSpawner;
    private VolcanoSpawner _volcanoSpawner;
    private SnowflakeSpawner _snowflakeSpawner;

    public MainSpawner(MainFactory mainFactory, LevelBordersMarker marker, LevelCounter levelCounter)
    {
        _coinsSpawner = new CoinsSpawner(marker, levelCounter, mainFactory.Coins);
        _treeSpawner = new TreeSpawner(marker, levelCounter, mainFactory.Trees);
        _volcanoSpawner = new VolcanoSpawner(marker, levelCounter, mainFactory.Volcanoes);
        _snowflakeSpawner = new SnowflakeSpawner(mainFactory.Snowflakes.Storage, _treeSpawner, marker);
    }

    public void Run()
    {
        _volcanoSpawner.Run();
        _treeSpawner.Run();
        _snowflakeSpawner.Run();
        _coinsSpawner.Run();
    }

    public void Clear()
    {

    }
}
