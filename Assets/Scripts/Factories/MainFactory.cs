public class MainFactory
{
    private CoinsFactory _coinsFactory;
    private TreeFactory _treeFactory;
    private VolcanoFactory _volcanoFactory;
    private SnowflakeFactory _snowflakeFactory;

    public MainFactory(MainFactoryConfig config, LevelCounter levelCounter, GrassPainter grassPainter, MainStorage mainStorage, GamePanel gamePanel)
    {
        _coinsFactory = new CoinsFactory(config.CoinFactoryConfig, mainStorage.Coins);
        _volcanoFactory = new VolcanoFactory(config.VolcanoFactoryConfig, levelCounter, mainStorage.Volcanoes, gamePanel);  
        _treeFactory = new TreeFactory(config.TreeFactoryConfig, levelCounter, grassPainter, mainStorage.Trees, gamePanel);
        _snowflakeFactory = new SnowflakeFactory(config.SnowflakeFactoryConfig, levelCounter, mainStorage.Snowflakes);
    }

    public VolcanoFactory Volcanoes => _volcanoFactory;

    public void Run()
    {
        _coinsFactory.Run();
        _treeFactory.Run();
        _volcanoFactory.Run();
        _snowflakeFactory.Run();
    }
}
