using UnityEngine;

[CreateAssetMenu(fileName ="MainFactoryConfig", menuName = "Configs/MainFactoryConfig")]
public class MainFactoryConfig : ScriptableObject
{
    [SerializeField] private CoinFactoryConfig _coinFactoryConfig;
    [SerializeField] private TreeFactoryConfig _treeFactoryConfig;

    public CoinFactoryConfig CoinFactoryConfig => _coinFactoryConfig;
    public TreeFactoryConfig TreeFactoryConfig => _treeFactoryConfig;
}
