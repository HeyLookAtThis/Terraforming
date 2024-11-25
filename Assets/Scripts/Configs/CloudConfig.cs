using UnityEngine;

[CreateAssetMenu(fileName = "CloudConfig", menuName = "Configs/CloudConfig")]
public class CloudConfig : ScriptableObject
{
    [SerializeField] private CloudUnderChatacterMoverConfig _cloudUnderChatacterMoverConfig;
    [SerializeField] private CloudWateringConfig _cloudWateringConfig;
    [SerializeField] private EmptyCloudConfig _emptyCloudConfig;

    public CloudUnderChatacterMoverConfig CloudToChatacterMoverConfig => _cloudUnderChatacterMoverConfig;
    public CloudWateringConfig CloudWateringConfig => _cloudWateringConfig;
    public EmptyCloudConfig EmptyCloudConfig => _emptyCloudConfig;
}
