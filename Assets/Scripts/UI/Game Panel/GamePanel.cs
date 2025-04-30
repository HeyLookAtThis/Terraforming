using Agava.WebUtility;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class GamePanel : Panel
{
    [SerializeField] private Thermometer _thermometer;
    [SerializeField] private GameObject _mobileInputPanel;

    private VolcanoesStorage _storage;
    private Character _character;

    private UnityAction _enabled;
    private UnityAction _disabled;

    public event UnityAction Enabled
    {
        add => _enabled += value;
        remove => _enabled -= value;
    }

    public event UnityAction Disabled
    {
        add => _disabled += value;
        remove => _disabled -= value;
    }

    private void OnEnable()
    {
        _enabled?.Invoke();

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
        _disabled?.Invoke();

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
