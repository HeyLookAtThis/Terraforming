using UnityEngine;

[CreateAssetMenu(fileName ="LevelConfig", menuName ="Configs/LevelConfig")]
public class LevelConfig : ScriptableObject
{
    [SerializeField] private LevelBoundariesMarkerConfig _markerConfig;
    [SerializeField] private LevelCounterConfig _counterConfig;

    public LevelBoundariesMarkerConfig MarkerConfig => _markerConfig;
    public LevelCounterConfig CounterConfig => _counterConfig;
}
