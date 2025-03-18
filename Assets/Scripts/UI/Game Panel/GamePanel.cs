using Agava.WebUtility;
using UnityEngine;
using Zenject;

public class GamePanel : Panel, IGameTimer
{
    [SerializeField] private Thermometer _thermometer;
    [SerializeField] private GameObject _mobileInputPanel;

    private VolcanoesStorage _storage;

    public float PlayingTimeScale => 1.0f;
    public float PausingTimeScale => 0.0f;

    private void OnEnable()
    {
        _storage.AllVolcanoesFrozen += PanelSwitcher.SwitchPanel<VictoryPanel>;
        _thermometer.ReachedMaxValue += PanelSwitcher.SwitchPanel<GameOverPanel>;

        _thermometer.InitializeValues();
        StartGame();

        if (Device.IsMobile)
            _mobileInputPanel.gameObject.SetActive(true);
        else
            _mobileInputPanel.gameObject.SetActive(false);        
    }

    private void OnDisable()
    {
        _storage.AllVolcanoesFrozen -= PanelSwitcher.SwitchPanel<VictoryPanel>;
        _thermometer.ReachedMaxValue -= PanelSwitcher.SwitchPanel<GameOverPanel>;

        StopGame();
    }

    [Inject]
    private void Construct(LevelBuilder levelBuilder)
    {
        _storage = levelBuilder.MainStorage.Volcanoes;
    }

    public void StartGame() => Time.timeScale = PlayingTimeScale;
    public void StopGame() => Time.timeScale = PausingTimeScale;
}
