using UnityEngine;
using Zenject;

public class GamePanel : MonoBehaviour, IPanel
{
    [SerializeField] private Thermometer _thermometer;

    private IPanelSwitcher _switcher;
    private VolcanoStorage _storage;

    private void OnEnable()
    {
        _storage.AllVolcanoesFrozen += _switcher.SwitchPanel<VictoryPanel>;
        _thermometer.ReachedMaxValue += _switcher.SwitchPanel<GameOverPanel>;
    }

    private void OnDisable()
    {
        _storage.AllVolcanoesFrozen -= _switcher.SwitchPanel<VictoryPanel>;
        _thermometer.ReachedMaxValue -= _switcher.SwitchPanel<GameOverPanel>;
    }

    [Inject]
    private void Construct(IPanelSwitcher panelSwitcher, LevelBuilder levelBuilder)
    {
        _storage = levelBuilder.MainStorage.Volcanoes;
        _switcher = panelSwitcher;
    }

    public void Hide() => gameObject.SetActive(false);

    public void Show() => gameObject.SetActive(true);
}
