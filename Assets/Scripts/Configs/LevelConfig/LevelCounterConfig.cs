using System;
using UnityEngine;

[Serializable]
public class LevelCounterConfig
{
    [field: SerializeField, Range(0, 7)] public int FirstLevelNumber { get; private set; }
    [field: SerializeField, Range(2, 7)] public int LastLevelNumber { get; private set; }
}
