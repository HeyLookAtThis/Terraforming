using UnityEngine;

[CreateAssetMenu(fileName = "CloudConfig", menuName = "Configs/CloudConfig")]
public class CloudConfig : ScriptableObject
{
    [SerializeField] private EmptyCloudConfig _emptyCloudConfig;
    [SerializeField] private WateringCloudConfig _wateringCloudConfig;

    public EmptyCloudConfig EmptyCloudConfig => _emptyCloudConfig;
    public WateringCloudConfig WateringCloudConfig => _wateringCloudConfig;
}
