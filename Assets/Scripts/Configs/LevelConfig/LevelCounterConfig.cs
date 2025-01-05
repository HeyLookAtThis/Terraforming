using System;
using UnityEngine;

[Serializable]
public class LevelCounterConfig
{
    [field: SerializeField, Range(1, 10)] public int FirstLevelNumber { get; private set; }
    [field: SerializeField, Range(2, 10)] public int LastLevelNumber { get; private set; }
}
