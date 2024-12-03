using UnityEngine;

[CreateAssetMenu(fileName ="LevelConfig", menuName ="Configs/LevelConfig")]
public class LevelConfig : ScriptableObject
{
    [SerializeField] private LevelBoundariesMarkerConfig _markerConfig;

    public LevelBoundariesMarkerConfig MarkerConfig => _markerConfig;
}
