using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Scanner
{
    private Cloud _cloud;
    private float _sphereRadius;
    private Collider[] _colliders;

    private UnityAction _foundWater;
    private UnityAction _lostWater;
    private UnityAction<Volcano> _foundVolcano;

    public Scanner(Cloud cloud)
    {
        _cloud = cloud;
        _sphereRadius = cloud.Config.CloudUnderChatacterConfig.ScannerRadius;
    }

    public event UnityAction FoundWater
    {
        add => _foundWater += value;
        remove => _foundWater -= value;
    }

    public event UnityAction LostWater
    {
        add => _lostWater += value;
        remove => _lostWater -= value;
    }

    public event UnityAction<Volcano> FoundVolcano
    {
        add => _foundVolcano += value;
        remove => _foundVolcano -= value;
    }

    private float YPosition => 1f;

    public void Update()
    {
        Vector3 position = new Vector3(_cloud.transform.position.x, YPosition, _cloud.transform.position.z);

        _colliders = Physics.OverlapSphere(position, _sphereRadius);
        CheckColliders();

        if(IsUnderWater())
            _foundWater?.Invoke();
        else
            _lostWater?.Invoke();
    }

    private bool IsUnderWater()
    {
        var waterCollider = _colliders.FirstOrDefault(collider => collider.TryGetComponent<Water>(out Water water));

        if(waterCollider == null)
            return false;

        return true;
    }

    private void CheckColliders()
    {
        foreach (var collider in _colliders)
        {
            if (collider.TryGetComponent<InteractiveObject>(out InteractiveObject interactionObject))
            {
                if (interactionObject.UsedByPlayer == false)
                {
                    if (_cloud.Reservoir.HaveWater)
                    {
                        if (interactionObject is Volcano == false)
                            interactionObject.ReactToScanner();
                        else
                            _foundVolcano?.Invoke((Volcano)interactionObject);
                    }

                }
            }
        }
    }
}
