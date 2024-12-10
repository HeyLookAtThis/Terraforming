using TMPro;
using UnityEngine;

public class CountDisplayer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinsCoint;
    [SerializeField] private TextMeshProUGUI _snowflakesCount;
    [SerializeField] private TextMeshProUGUI _volcanoesCount;

    public void ShowCoins(int count) => _coinsCoint.text = count.ToString();
    public void ShowSnowflakes(int count) => _snowflakesCount.text = count.ToString();
    public void ShowVolcanoes(int freezedCount, int totalCount) => _snowflakesCount.text = $"{freezedCount}/{totalCount}";
}
