using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Volcano : InteractiveObject, IAtmosphereHeater
{
    [SerializeField] VolcanoView _view;

    private Coroutine _heatGenerator;

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

    public bool IsFrozen => UsedByPlayer;

    public override void ReactToScanner()
    {
        if (UsedByPlayer == false)
        {
            _view.Freeze();
            TurnOnUsed();
        }
    }

    public override void ReturnToDefaultState() => gameObject.SetActive(true);

    public void BeginHeatGround()
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
        {
            _wasFrozen?.Invoke();
            yield break;
        }
    }
}