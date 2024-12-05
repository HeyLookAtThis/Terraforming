public class MainFactory
{
    private CoinsFactory _coinsFactory;
    private TreeFactory _treeFactory;
    private VolcanoFactory _volcanoFactory;
    private SnowflakeFactory _snowflakeFactory;

    public MainFactory(MainFactoryConfig config, LevelCounter levelCounter, GrassPainter grassPainter)
    {
        _coinsFactory = new CoinsFactory(config.CoinFactoryConfig);
        _treeFactory = new TreeFactory(config.TreeFactoryConfig, levelCounter, grassPainter);
        _volcanoFactory = new VolcanoFactory(config.VolcanoFactoryConfig, levelCounter);  
        _snowflakeFactory = new SnowflakeFactory(config.SnowflakeFactoryConfig, levelCounter);
    }

    public CoinsFactory Coins => _coinsFactory;
    public TreeFactory Trees => _treeFactory;
    public VolcanoFactory Volcanoes => _volcanoFactory;
    public SnowflakeFactory Snowflakes => _snowflakeFactory;

    public void Run()
    {
        _coinsFactory.Run();
        _treeFactory.Run();
        _volcanoFactory.Run();
        _snowflakeFactory.Run();
    }
}
