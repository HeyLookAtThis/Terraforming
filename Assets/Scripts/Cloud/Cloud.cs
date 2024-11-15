using UnityEngine;

public class Cloud : MonoBehaviour
{
    [SerializeField] private CloudConfig _config;

    private IMover _mover;

    public CloudConfig Config => _config;

    private void Update() => _mover.Update(Time.deltaTime);

    public void SetMover(IMover mover)
    {
        _mover?.StopMove();
        _mover = mover;
        _mover.StartMove();
    }
}
