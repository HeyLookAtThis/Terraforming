using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Scanner : IDisposable
{
    private Cloud _cloud;
    private Collider[] _colliders;
    private WateringCloudMover _wateringCloudMover;

    private float _sphereRadius;
    private bool _isActive;

    private UnityAction<Volcano> _foundVolcano;
    private UnityAction _foundWater;
    private UnityAction _lostWater;

    public Scanner(Cloud cloud, WateringCloudMover wateringCloudMover)
    {
        _cloud = cloud;
        _sphereRadius = cloud.Config.CloudUnderChatacterConfig.ScannerRadius;

        _isActive = true;

        _wateringCloudMover = wateringCloudMover;
        _wateringCloudMover.ChangedActivity += OnSetActivity;
    }

    public event UnityAction<Volcano> FoundVolcano
    {
        add => _foundVolcano += value;
        remove => _foundVolcano -= value;
    }

    public event UnityAction FoudWater
    {
        add => _foundWater += value;
        remove => _foundWater -= value;
    }

    public event UnityAction LostWater
    {
        add => _foundWater += value;
        remove => _foundWater -= value;
    }

    private float YPosition => 1f;

    public void Dispose() => _wateringCloudMover.ChangedActivity -= OnSetActivity;

    public void Update()
    {
        if (_isActive == false)
            return;

        Vector3 position = new Vector3(_cloud.transform.position.x, YPosition, _cloud.transform.position.z);
        _colliders = Physics.OverlapSphere(position, _sphereRadius);

        TryFindObjects();
        TryFindWater();
    }

    private void OnSetActivity(bool activity) => _isActive = activity;

    private void TryFindObjects()
    {
        foreach (var collider in _colliders)
            if (collider.TryGetComponent<InteractiveObject>(out InteractiveObject interactionObject))
                TryActivateInteractiveObject(interactionObject);
    }

    private void TryFindWater()
    {
        var collider = _colliders.FirstOrDefault(collider => collider.TryGetComponent<Water>(out Water water));

        if (collider != null)
            _foundWater?.Invoke();
        else
            _lostWater?.Invoke();
    }

    private void TryActivateInteractiveObject(InteractiveObject interactiveObject)
    {
        if (interactiveObject.UsedByPlayer == false)
        {
            if (_cloud.Resizer.HaveWater)
            {
                if (interactiveObject is Volcano == false)
                    interactiveObject.ReactToScanner();
                else
                    _foundVolcano?.Invoke((Volcano)interactiveObject);
            }
        }
    }
}
