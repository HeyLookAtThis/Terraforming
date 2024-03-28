using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerInstantiator))]
public class LevelFinisher : MonoBehaviour
{
    private PlayerInstantiator _instantiator;

    private Coroutine _runner;

    private UnityAction _run;

    public event UnityAction Run
    {
        add => _run += value;
        remove => _run -= value;
    }

    private void Awake()
    {
        _instantiator = GetComponent<PlayerInstantiator>();
    }

    private void OnEnable()
    {
        _instantiator.Created += Subscribe;
    }

    private void OnDisable()
    {
        _instantiator.Created -= Subscribe;

        if (_instantiator.Player != null)
            _instantiator.Player.Counter.AllVolcanoesFreezed -= Begin;
    }

    public void Subscribe(Player player)
    {
        player.Counter.AllVolcanoesFreezed += Begin;
    }

    private void Begin()
    {
        if (_runner != null)
            StopCoroutine(_runner);

        _runner = StartCoroutine(TimeStopper());
    }

    private IEnumerator TimeStopper()
    {
        float time = 0.5f;
        float seconds = 0.1f;
        var waitTime = new WaitForEndOfFrame();

        float secondsCounter = 0f;

        while (time > secondsCounter)
        {
            if (Time.timeScale > seconds)
                Time.timeScale -= Time.deltaTime;

            secondsCounter += Time.deltaTime;
            yield return waitTime;
        }

        if (secondsCounter >= time)
        {
            _run?.Invoke();
            yield break;
        }
    }
}
