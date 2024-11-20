using UnityEngine;

public class Cloud : MonoBehaviour
{
    [SerializeField] private CloudConfig _config;

    public CloudConfig Config => _config;
}
