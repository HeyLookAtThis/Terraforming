using DG.Tweening;
using System.Collections;
using UnityEngine;

public class Volcano : InteractionObject
{
    [SerializeField] private float _temperature;
    [SerializeField] private Color _iceColor;
    [SerializeField] private MeshRenderer _renderer;
    [SerializeField] private ParticleSystem _smoke;
    //[SerializeField] private FreezEffect _freezEffect;

    private delegate void DelegateMethod(float time);

    private Coroutine _heatGenerator;
    private Coroutine _freezer;

    private bool _isFrozenColor => _renderer.material.color == _iceColor;

    public float Temperature => _temperature;

    public override void ReactToScanner(Player player)
    {
        if(WasUsedByPlayer == false && player.HaveCristall)
        {
            TurnOnUsed();

            //_smoke.Stop();
            //_freezEffect.Play();

            float colorChangeTime = 0.2f;
            DelegateMethod action = ChangeColor;
            RunCoroutine(_freezer, ActionEnumerator(action, colorChangeTime, _isFrozenColor));

            player.UseObject(this);
            player.RemoveCristall();
        }
    }

    public override void ReactToTree()
    {
    }

    public override void ReturnToDefaultState()
    {
        Destroy(gameObject);
    }

    public void BeginHeatGround(Ground ground)
    {
        float heatGaineTime = 1f;
        DelegateMethod action = ground.AddTemperature;
        RunCoroutine(_heatGenerator, ActionEnumerator(action, heatGaineTime, WasUsedByPlayer));
    }

    private void ChangeColor(float timeAmount)
    {
        float colorChangeSpeed = 2f;

        _renderer.material.DOColor(_iceColor, timeAmount * colorChangeSpeed);
    }

    private void RunCoroutine(Coroutine coroutine, IEnumerator routine)
    {
        if(coroutine != null)
            StopCoroutine(coroutine);

        coroutine = StartCoroutine(routine);
    }

    private IEnumerator ActionEnumerator(DelegateMethod action, float time, bool isSucssesCondition)
    {
        var waitTime = new WaitForSecondsRealtime(time);

        while(!isSucssesCondition)
        {
            action(time);
            yield return waitTime;
        }

        if (isSucssesCondition)
            yield break;
    }
}