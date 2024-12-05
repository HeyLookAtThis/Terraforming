using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Volcano : InteractiveObject, IInteractiveObject
{
    [SerializeField] VolcanoView _view;

    private Coroutine _heatGenerator;

    private UnityAction _wasFrozen;
    private UnityAction<float> _heating;

    public Transform Transform { get => transform; set => transform.position = value.position; }

    public event UnityAction WasFrozen
    {
        add => _wasFrozen += value;
        remove => _wasFrozen -= value;
    }

    public event UnityAction<float> Heating
    {
        add => _heating += value;
        remove => _heating -= value;
    }

    public override void ReactToScanner()
    {
        if (UsedByPlayer == false)
        {
            _view.Freeze();
            TurnOnUsed();
        }
    }

    public override void ReturnToDefaultState() => gameObject.SetActive(false);

    public void BeginHeatGround()
    {
        if (_heatGenerator != null)
            StopCoroutine(_heatGenerator);

        _heatGenerator = StartCoroutine(GroundHeater());
    }

    private IEnumerator GroundHeater()
    {
        var waitTime = new WaitForEndOfFrame();

        while(UsedByPlayer == false)
        {
            _heating?.Invoke(Time.deltaTime);
            yield return waitTime;
        }

        if (UsedByPlayer)
        {
            _wasFrozen?.Invoke();
            yield break;
        }
    }
}