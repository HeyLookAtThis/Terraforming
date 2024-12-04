using System;
using UnityEngine;

[Serializable]
public class LevelBoundariesMarkerConfig
{
    [field: SerializeField,Range(0,10)] public float Offset { get; private set; }
}
