using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(RewardCounter))]
public class RewardCounterView : MonoBehaviour
{
    [SerializeField] private float _replaceTime;

    private TextMeshProUGUI _textMeshPro;
    private Coroutine _runner;

    private RewardCounter _counter;

    private void Awake()
    {
        _textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        _counter = GetComponent<RewardCounter>();
    }

    private void OnEnable()
    {
        Begin();
    }

    private void Begin()
    {
        if(_runner != null)
            StopCoroutine(_runner);

        _runner = StartCoroutine(TextChanger());
    }

    private IEnumerator TextChanger()
    {
        var waitTime = new WaitForSecondsRealtime(_replaceTime);
        float value = 0;

        while(value < _counter.Value)
        {
            value++;
            _textMeshPro.text = value.ToString();
            yield return waitTime;
        }

        if(value == _counter.Value)
            yield break;
    }
}
