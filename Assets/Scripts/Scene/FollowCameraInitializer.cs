using Cinemachine;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class FollowCameraInitializer : MonoBehaviour
{
    private CinemachineVirtualCamera _camera;

    [Inject]
    private void Construct(ITarget target)
    {
        _camera = GetComponent<CinemachineVirtualCamera>();
        _camera.Follow = target.Transform;
        _camera.LookAt = target.Transform;
    }
}
