using System.Collections;
using TMPro;
using UnityEngine;

public class VictoryCoinsView : MonoBehaviour
{
    [SerializeField] private Score _score;
    [SerializeField] private TextMeshProUGUI _value;

    private Coroutine _shower;

    private void OnEnable() => ShowValue();

    private void ShowValue()
    {
        if (_shower != null)
            StopCoroutine(_shower);

        _shower = StartCoroutine(Shower());
    }

    private IEnumerator Shower()
    {
        _value.text = _score.Value.ToString();
        var waitTime = new WaitForEndOfFrame();
        int targetValue = _score.Value;

        while (targetValue != _score.EstimatedValue)
        {
            targetValue++;
            _value.text = targetValue.ToString();
            yield return waitTime;
        }

        if (targetValue == _score.EstimatedValue)
            yield break;
    }
}
