using System;
using UnityEngine;

[Serializable]
public class SitOnCloudConfig
{
    [SerializeField, Range(1, 10)] private float _speed;

    public float Speed => _speed;
}
