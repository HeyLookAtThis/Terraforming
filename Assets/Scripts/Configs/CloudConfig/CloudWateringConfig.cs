using System;
using UnityEngine;

[Serializable]
public class CloudWateringConfig
{
    [field: SerializeField, Range(5, 15)] public int GrassPainterRadius { get; private set; }
    [field: SerializeField, Range(1, 10)] public float WateringTime { get; private set; }
    [field: SerializeField, Range(0.1f, 0.5f)] public float MinSize { get; private set; }
    [field: SerializeField, Range(0.001f, 0.01f)] public float DecreaseSpeed { get; private set; }
}
