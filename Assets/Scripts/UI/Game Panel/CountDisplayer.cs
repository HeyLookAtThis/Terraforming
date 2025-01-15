using TMPro;
using UnityEngine;

public class CountDisplayer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinsCoint;
    [SerializeField] private TextMeshProUGUI _snowflakesCount;
    [SerializeField] private TextMeshProUGUI _volcanoesCount;

    public void OnShowCoins(int count) => _coinsCoint.text = count.ToString();
    public void OnShowSnowflakes(int count) => _snowflakesCount.text = count.ToString();
    public void ShowVolcanoes(int freezedCount, int totalCount) => _volcanoesCount.text = $"{freezedCount}/{totalCount}";
}
