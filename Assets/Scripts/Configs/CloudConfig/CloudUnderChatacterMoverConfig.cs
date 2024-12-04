using System;
using UnityEngine;

[Serializable]
public class CloudUnderChatacterMoverConfig
{
    [field: SerializeField, Range(20, 50)] public float Speed { get; private set; }
    [field: SerializeField, Range(0.6f, 1f)] public float MaxSize { get; private set; }
    [field: SerializeField, Range(1f, 5f)] public float FillingSpeed { get; private set; }
    [field: SerializeField, Range(0.1f, 1f)] public float IncreaseSpeed { get; private set; }
    [field: SerializeField, Range(0.5f, 3f)] public float ScannerRadius { get; private set; }
}
