using UnityEngine;
using UnityEngine.Events;

public class PanelsSwitcher : MonoBehaviour
{
    [SerializeField] private Ground _ground;
    [SerializeField] private LevelFinisher _levelFinisher;

    private Panel[] _panels;

    private TitlePanel _title;
    private LoadingPanel _loadingPanel;
    private MenuPanel _menu;
    private GamePanel _game;
    private GameOverPanel _gameOver;
    private WinPanel _win;

    private UnityAction<Panel> _changedPanel;

    public event UnityAction<Panel> ChangedPanel
    {
        add => _changedPanel += value;
        remove => _changedPanel -= value;
    }

    private void Awake()
    {
        _title = GetComponentInChildren<TitlePanel>();
        _loadingPanel = GetComponentInChildren<LoadingPanel>();
        _menu = GetComponentInChildren<MenuPanel>();
        _game = GetComponentInChildren<GamePanel>();
        _gameOver = GetComponentInChildren<GameOverPanel>();
        _win = GetComponentInChildren<WinPanel>();

        _panels = new Panel[] { _title, _loadingPanel, _menu, _game, _win, _gameOver };
    }

    private void OnEnable()
    {
        _title.Clicked += OnRunMenu;

        _menu.Start.AddListener(OnRunLoading);

        _loadingPanel.Bar.Finished += OnRunGame;

        _win.RestartButton.AddListener(OnRunLoading);
        _win.ContinueButton.AddListener(OnRunLoading);
        _gameOver.RestartButton.AddListener(OnRunLoading);

        _levelFinisher.Run += OnRunWin;
        _ground.Overheated += OnRunGameOver;
    }

    private void OnDisable()
    {
        _title.Clicked -= OnRunMenu;

        _menu.Start.RemoveListener(OnRunLoading);

        _loadingPanel.Bar.Finished -= OnRunGame;

        _win.RestartButton.RemoveListener(OnRunLoading);
        _win.ContinueButton.RemoveListener(OnRunLoading);
        _gameOver.RestartButton.RemoveListener(OnRunLoading);

        _levelFinisher.Run -= OnRunWin;
        _ground.Overheated -= OnRunGameOver;
    }

    private void Start()
    {
        RunTitle();
    }

    private void RunTitle()
    {
        Run(_title);
        _changedPanel?.Invoke(_title);
    }

    private void OnRunMenu()
    {
        Run(_menu);
        _changedPanel?.Invoke(_menu);
    }

    private void OnRunLoading()
    {
        Time.timeScale = 1f;
        Run(_loadingPanel);
        _changedPanel?.Invoke(_loadingPanel);
    }

    private void OnRunGameOver()
    {
        Run(_gameOver);
        Time.timeScale = 0f;
        _changedPanel?.Invoke(_gameOver);
    }

    private void OnRunWin()
    {
        Run(_win);
        Time.timeScale = 0f;
        _changedPanel?.Invoke(_win);
    }

    private void OnRunGame()
    {
        Run(_game);
        Time.timeScale = 1f;
        _changedPanel?.Invoke(_game);
    }

    private void Run(Panel somePanel)
    {
        foreach (var panel in _panels)
        {
            if (panel == somePanel)
                panel.gameObject.SetActive(true);
            else
                panel.gameObject.SetActive(false);
        }
    }
}
