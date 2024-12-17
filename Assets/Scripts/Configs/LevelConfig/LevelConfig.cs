using UnityEngine;

[CreateAssetMenu(fileName ="LevelConfig", menuName ="Configs/LevelConfig")]
public class LevelConfig : ScriptableObject
{
    [SerializeField] private LevelBordersConfig _markerConfig;
    [SerializeField] private LevelCounterConfig _counterConfig;
    [SerializeField] private AtmosphereConfig _atmosphereConfig;

    public LevelBordersConfig MarkerConfig => _markerConfig;
    public LevelCounterConfig CounterConfig => _counterConfig;
    public AtmosphereConfig AtmosphereConfig => _atmosphereConfig;
}
