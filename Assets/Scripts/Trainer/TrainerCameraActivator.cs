using Cinemachine;
using UnityEngine;

public class TrainerCameraActivator : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _camera;

    private float _passedTime;

    private float ShowingTime => 2.5f;

    private void Update()
    {
        if (_camera.gameObject.activeSelf == false)
            return;

        _passedTime += Time.deltaTime;

        if (_passedTime >= ShowingTime)
        {
            _passedTime = 0;
            TurnOff();
        }
    }

    public void SetTarget(Transform transform)
    {
        _camera.Follow = transform;
        _camera.LookAt = transform;
        TurnOn();
    }

    private void TurnOn()
    {
        _camera.gameObject.SetActive(true);
        gameObject.SetActive(true);
    }

    private void TurnOff()
    {
        _camera.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
