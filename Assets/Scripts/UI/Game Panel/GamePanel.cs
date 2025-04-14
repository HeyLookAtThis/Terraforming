using Agava.WebUtility;
using UnityEngine;
using Zenject;

public class GamePanel : Panel
{
    [SerializeField] private Thermometer _thermometer;
    [SerializeField] private GameObject _mobileInputPanel;

    private VolcanoesStorage _storage;
    private Character _character;

    public float PlayingTimeScale => 1.0f;
    public float PausingTimeScale => 0.0f;

    private void OnEnable()
    {
        _storage.AllVolcanoesFrozen += PanelSwitcher.SwitchPanel<VictoryPanel>;
        _thermometer.ReachedMaxValue += PanelSwitcher.SwitchPanel<GameOverPanel>;

        _thermometer.InitializeValues();
        _character.Activate();

        if (Device.IsMobile)
            _mobileInputPanel.gameObject.SetActive(true);
        else
            _mobileInputPanel.gameObject.SetActive(false);        
    }

    private void OnDisable()
    {
        _storage.AllVolcanoesFrozen -= PanelSwitcher.SwitchPanel<VictoryPanel>;
        _thermometer.ReachedMaxValue -= PanelSwitcher.SwitchPanel<GameOverPanel>;

        _character.Deactivate();
    }

    [Inject]
    private void Construct(LevelBuilder levelBuilder, Character character)
    {
        _storage = levelBuilder.MainStorage.Volcanoes;
        _character = character;
    }
}
