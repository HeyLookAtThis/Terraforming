using UnityEngine;

[CreateAssetMenu(fileName = "CloudConfig", menuName = "Configs/CloudConfig")]
public class CloudConfig : ScriptableObject
{
    [SerializeField] private CloudUnderChatacterMoverConfig _cloudUnderChatacterMoverConfig;
    [SerializeField] private EmptyCloudConfig _emptyCloudConfig;

    public CloudUnderChatacterMoverConfig CloudToChatacterMoverConfig => _cloudUnderChatacterMoverConfig;
    public EmptyCloudConfig EmptyCloudConfig => _emptyCloudConfig;
}
