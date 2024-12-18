using TMPro;
using UnityEngine;

public class FactsBoard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _tMPro;
    [SerializeField] private string[] _facts;

    private void OnEnable() => _tMPro.text = ShowRandomFact();

    private string ShowRandomFact() => _facts[Random.Range(0, _facts.Length - 1)];
}
