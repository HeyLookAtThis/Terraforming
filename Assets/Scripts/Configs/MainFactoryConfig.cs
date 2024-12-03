using UnityEngine;

[CreateAssetMenu(fileName ="MainFactoryConfig", menuName = "Configs/MainFactoryConfig")]
public class MainFactoryConfig : ScriptableObject
{
    [SerializeField] private CoinFactoryConfig _coinFactoryConfig;

    public CoinFactoryConfig CoinFactoryConfig => _coinFactoryConfig;
}
