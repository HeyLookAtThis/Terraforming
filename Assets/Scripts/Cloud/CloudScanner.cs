using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Cloud), typeof(CloudReservoir), typeof(CloudWithWaterState))]
public class CloudScanner : MonoBehaviour
{
    private float _radius;
    private float _yPosition;
    private bool _isActivated;

    private Collider[] _colliders;
    private CloudReservoir _reservoir;
    private Cloud _cloud;

    private Vector3 _spherePosition;
    private Vector3 _nextSpherePosition;

    private UnityAction _foundWater;
    private UnityAction _foundInteractionObject;

    public event UnityAction FoundWater
    {
        add => _foundWater += value;
        remove => _foundWater -= value;
    }

    public event UnityAction FoundInteractionObject
    {
        add => _foundInteractionObject += value;
        remove => _foundInteractionObject -= value;
    }

    private void Awake()
    {
        _reservoir = GetComponent<CloudReservoir>();
        _cloud = GetComponent<Cloud>();

        _radius = 1;
        _yPosition = 1;

        _spherePosition = new Vector3(transform.position.x, _yPosition, transform.position.z);
        _colliders = Physics.OverlapSphere(_spherePosition, _radius);
    }

    private void OnEnable()
    {
        GetComponent<CloudWithWaterState>().TookPosition += Activate;
        _reservoir.WaterIsOver += Deactivate;
    }

    private void OnDisable()
    {
        GetComponent<CloudWithWaterState>().TookPosition -= Activate;
        _reservoir.WaterIsOver -= Deactivate;
    }

    private void Update()
    {
        if (_isActivated)
        {
            _spherePosition = new Vector3(transform.position.x, _yPosition, transform.position.z);

            if (IsContainsWater())
                _foundWater?.Invoke();

            if (_spherePosition != _nextSpherePosition)
            {
                _colliders = GetSubstractColliders();
                CheckColliders();

                _nextSpherePosition = _spherePosition;
                _colliders = Physics.OverlapSphere(_nextSpherePosition, _radius);
            }
        }
    }

    public void Activate()
    {
        if (_isActivated == false)
        {
            ClearColliders();
            _isActivated = true;
        }
    }

    private void Deactivate()
    {
        if (_isActivated)
        {
            _isActivated = false;
            ClearColliders();
        }
    }

    private void ClearColliders()
    {
        _colliders = new Collider[0];
    }

    public bool IsContainsWater()
    {
        var waterCollider = _colliders.Where(collider => collider.TryGetComponent<Water>(out Water water)).FirstOrDefault();

        if (waterCollider != null)
            return true;

        return false;
    }

    private Collider[] GetSubstractColliders()
    {
        return Physics.OverlapSphere(_spherePosition, _radius).Except(_colliders).ToArray();
    }

    private void CheckColliders()
    {
        foreach (var collider in _colliders)
        {
            if (collider.TryGetComponent<InteractionObject>(out InteractionObject interactionObject))
            {
                if(interactionObject.WasUsedByPlayer == false)
                {
                    _foundInteractionObject?.Invoke();

                    if (_reservoir.HaveWater)
                        interactionObject.ReactToPlayer(_cloud.Player);
                }
            }

            //if (collider.TryGetComponent<Plant>(out var plant))
            //{
            //    if (plant.IsGreen == false)
            //    {
            //        _foundDryPlant?.Invoke();

            //        if (_reservoir.HaveWater)
            //            plant.MakeGreen();
            //    }
            //}

            //    if (collider.TryGetComponent<Coin>(out var coin))
            //        coin.TurnOn();

            //    if (collider.TryGetComponent<Volcano>(out var volcano))
            //    {
            //        if (_cloud.Player.HaveCristall && volcano.IsFrozen == false)
            //        {
            //            volcano.Freeze();
            //            _cloud.Player.RemoveIceCristall();
            //        }
            //    }
        }
    }
}