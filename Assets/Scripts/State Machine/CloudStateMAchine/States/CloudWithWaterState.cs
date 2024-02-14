using UnityEditor.Experimental.GraphView;
using UnityEngine;

[RequireComponent(typeof(Cloud), typeof(CloudResizer))]
public class CloudWithWaterState : CloudState
{
    private CloudResizer _resizer;

    private float _fullsize = 16f;

    private void Awake()
    {
        _resizer = GetComponent<CloudResizer>();
    }

    private void Update()
    {
        positionIndent.y = _fullsize * _resizer.CurrentValue;
        targetPosition = Target.position - positionIndent;

        Move(targetPosition);

        transform.forward = Target.forward;
    }
}