using System;
using UnityEngine;

[Serializable]
public class AirborneStateConfig
{
    [SerializeField] private JumpingStateConfig _jumpingStateConfig;
    [SerializeField] private SitOnCloudConfig _sitOnCloudConfig;

    public JumpingStateConfig JumpingStateConfig => _jumpingStateConfig;
    public SitOnCloudConfig SitOnCloudConfig => _sitOnCloudConfig;
    public float BaseGravity => 2 * _jumpingStateConfig.MaxHeight / (_jumpingStateConfig.TimeToReachMaxHeight * _jumpingStateConfig.TimeToReachMaxHeight);
}
