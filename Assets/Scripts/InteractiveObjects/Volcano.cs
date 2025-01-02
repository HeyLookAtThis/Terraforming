using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Volcano : InteractiveObject, IAtmosphereHeater
{
    [SerializeField] VolcanoView _view;

    private Coroutine _heatGenerator;
    private bool _isFrozen;

    private UnityAction _wasFrozen;
    private UnityAction<float> _heating;

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

    public bool IsFrozen => _isFrozen;

    public override void ReactToScanner()
    {
        if (UsedByPlayer == false)
        {
            TurnOnUsed();
            _view.Freeze();
        }
    }

    public override void SetDefaultState()
    {
        TurnOffUsed();
        BeginHeatGround();
    }

    public void Freeze()
    {
        _isFrozen = true;
        _wasFrozen?.Invoke();
        gameObject.SetActive(false);
    }

    private void BeginHeatGround()
    {
        if (_heatGenerator != null)
            StopCoroutine(_heatGenerator);

        _heatGenerator = StartCoroutine(GroundHeater());
    }

    private IEnumerator GroundHeater()
    {
        var waitTime = new WaitForEndOfFrame();

        while(IsFrozen == false)
        {
            _heating?.Invoke(Time.deltaTime);
            yield return waitTime;
        }

        if (IsFrozen)
            yield break;
    }
}