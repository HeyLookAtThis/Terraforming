public class MainStorage
{
    private CoinsStorage _coins;
    private VolcanoStorage _volcanoes;
    private TreesStorage _trees;
    private SnowflakesStorage _snowflakes;

    public MainStorage()
    {
        string coinsStorageName = "CoinStorage";
        _coins = new CoinsStorage(coinsStorageName);

        string volcanoStorageName = "VolcanoStorage";
        _volcanoes = new VolcanoStorage(volcanoStorageName);

        string treesStorageName = "TreesStorage";
        _trees = new TreesStorage(treesStorageName);

        string snowflakesStorageName = "SnowflakeStorage";
        _snowflakes = new SnowflakesStorage(snowflakesStorageName);
    }

    public CoinsStorage Coins => _coins;
    public VolcanoStorage Volcanoes => _volcanoes;
    public TreesStorage Trees => _trees;
    public SnowflakesStorage Snowflakes => _snowflakes;

    public void Clear()
    {
        _coins.Clear();
        _volcanoes.Clear();
        _trees.Clear();
        _snowflakes.Clear();
    }
}
