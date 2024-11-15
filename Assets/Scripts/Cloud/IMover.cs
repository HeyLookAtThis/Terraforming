using UnityEngine;

public interface IMover
{
    Transform Transform { get; }
    Transform Target { get; }

    void StartMove();
    void StopMove();
    void Update(float timeDeltaTime);
    void Move(Vector3 translation, float timeDeltaTime);
}
