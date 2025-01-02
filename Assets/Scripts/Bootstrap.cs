using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private PanelsSwitcher _panelsSwitcher;

    private void Awake() => _panelsSwitcher.Initialize();
}
