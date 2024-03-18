using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class GameButton : MonoBehaviour
{
    private Button _clickObject;

    private void Awake()
    {
        _clickObject = GetComponent<Button>();
    }

    public void AddListener(UnityAction action)
    {
        _clickObject.onClick.AddListener(action);
    }

    public void RemoveListener(UnityAction action)
    {
        _clickObject.onClick.RemoveListener(action);
    }
}
