using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(VolcanoView))]
public class Volcano : InteractiveObject
{
    [SerializeField] private float _temperature;

    private delegate void DelegateMethod(float time);

    private Coroutine _heatGenerator;

    private UnityAction _wasFrozen;

    public event UnityAction WasFrozen
    {
        add => _wasFrozen += value;
        remove => _wasFrozen -= value;
    }

    public float Temperature => _temperature;

    //public override void ReactToScanner(PlayerObjectsCounter player)
    //{
    //    if(UsedByPlayer == false && player.HaveCristall)
    //    {
    //        TurnOnUsed();
    //        player.UseObject(this);
    //        player.RemoveCristall();
    //    }
    //}

    public override void ReturnToDefaultState()
    {
        Destroy(gameObject);
    }

    public void BeginHeatGround(OldGround ground)
    {
        float heatGaineTime = 1f;
        GetComponent<VolcanoView>().SetStartingEffectsState();
        DelegateMethod action = ground.AddTemperature;

        if (_heatGenerator != null)
            StopCoroutine(_heatGenerator);

        _heatGenerator = StartCoroutine(ActionEnumerator(action, heatGaineTime));
    }

    private IEnumerator ActionEnumerator(DelegateMethod action, float time)
    {
        float heatGaineTime = 1f;

        var waitTime = new WaitForSecondsRealtime(heatGaineTime);

        while(!UsedByPlayer)
        {
            action(time);
            yield return waitTime;
        }

        if (UsedByPlayer)
        {
            _wasFrozen?.Invoke();
            yield break;
        }
    }
}