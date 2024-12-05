using UnityEngine;

[CreateAssetMenu(fileName ="MainFactoryConfig", menuName = "Configs/MainFactoryConfig")]
public class MainFactoryConfig : ScriptableObject
{
    [SerializeField] private CoinFactoryConfig _coinFactoryConfig;
    [SerializeField] private TreeFactoryConfig _treeFactoryConfig;
    [SerializeField] private VolcanoFactoryConfig _volcanoFactoryConfig;
    [SerializeField] private SnowflakeFactoryConfig _snowflakeFactoryConfig;

    public CoinFactoryConfig CoinFactoryConfig => _coinFactoryConfig;
    public TreeFactoryConfig TreeFactoryConfig => _treeFactoryConfig;
    public VolcanoFactoryConfig VolcanoFactoryConfig => _volcanoFactoryConfig;
    public SnowflakeFactoryConfig SnowflakeFactoryConfig => _snowflakeFactoryConfig;
}
