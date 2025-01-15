using UnityEngine;
using Zenject;

public class GamePanel : MonoBehaviour, IPanel, IGameTimer
{
    [SerializeField] private Thermometer _thermometer;
    [SerializeField] private Panel _mobileInputPanel;

    private IPanelSwitcher _switcher;
    private VolcanoStorage _storage;

    public float PlayingTimeScale => 1.0f;
    public float PausingTimeScale => 0.0f;

    private void OnEnable()
    {
        _storage.AllVolcanoesFrozen += _switcher.SwitchPanel<VictoryPanel>;
        _thermometer.ReachedMaxValue += _switcher.SwitchPanel<GameOverPanel>;

        _thermometer.InitializeValues();
        StartGame();

        if (SystemInfo.deviceType == DeviceType.Desktop)
            _mobileInputPanel.gameObject.SetActive(false);
        else
            _mobileInputPanel.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        _storage.AllVolcanoesFrozen -= _switcher.SwitchPanel<VictoryPanel>;
        _thermometer.ReachedMaxValue -= _switcher.SwitchPanel<GameOverPanel>;

        StopGame();
    }

    [Inject]
    private void Construct(IPanelSwitcher panelSwitcher, LevelBuilder levelBuilder)
    {
        _storage = levelBuilder.MainStorage.Volcanoes;
        _switcher = panelSwitcher;
    }

    public void Hide() => gameObject.SetActive(false);
    public void Show() => gameObject.SetActive(true);
    public void StartGame() => Time.timeScale = PlayingTimeScale;
    public void StopGame() => Time.timeScale = PausingTimeScale;
}
