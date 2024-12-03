using System;
using UnityEngine;

[Serializable]
public class CoinFactoryConfig
{
    [field: SerializeField] public Coin Prefab { get; private set; }
    [field: SerializeField, Range(1, 300)] public int Count { get; private set; }
}
