using System;
using UnityEngine;

[Serializable]
public class LevelCounterConfig
{
    [field: SerializeField, Range(1, 12)] public int FirstLevelNumber { get; private set; }
    [field: SerializeField, Range(2, 12)] public int LastLevelNumber { get; private set; }
}
