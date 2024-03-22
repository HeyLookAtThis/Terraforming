using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class GameButton : MonoBehaviour
{
    [SerializeField] private Button _clickObject;

    public void AddListener(UnityAction action)
    {
        _clickObject.onClick.AddListener(action);
    }

    public void RemoveListener(UnityAction action)
    {
        _clickObject.onClick.RemoveListener(action);
    }
}
