using System;
using UnityEngine;

[Serializable]
public class CloudUnderChatacterMoverConfig
{
    [field: SerializeField, Range(20, 50)] public float Speed { get; private set; }
}
