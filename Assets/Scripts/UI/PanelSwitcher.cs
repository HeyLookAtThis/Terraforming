using UnityEngine;

public class PanelSwitcher : MonoBehaviour
{
    [SerializeField] private Ground _ground;
    [SerializeField] private VolcanoesDisplayer _volcanoDisplayer;
    [SerializeField] private LoadingBar _loadingBar;

    private Panel[] _panels;

    private TitlePanel _title;
    private MenuPanel _menu;
    private GamePanel _game;
    private GameOverPanel _gameOver;
    private WinPanel _win;

    private void Awake()
    {
        _title = GetComponentInChildren<TitlePanel>();
        _menu = GetComponentInChildren<MenuPanel>();
        _game = GetComponentInChildren<GamePanel>();
        _gameOver = GetComponentInChildren<GameOverPanel>();
        _win = GetComponentInChildren<WinPanel>();

        _panels = new Panel[] { _title, _menu, _game, _win, _gameOver };
    }

    private void OnEnable()
    {
        _title.Clicked += OnRunMenu;
        _loadingBar.Finished += OnRunGame;

        _gameOver.RestartAction += OnRunGame;
        _win.RestartButtonClicked += OnRunGame;
        _win.ContinueButtonClicked += OnRunGame;

        _volcanoDisplayer.Fulled += OnRunWin;
        _ground.Overheated += OnRunGameOver;
    }

    private void OnDisable()
    {
        _title.Clicked -= OnRunMenu;
        _loadingBar.Finished -= OnRunGame;

        _win.ContinueButtonClicked -= OnRunGame;
        _win.RestartButtonClicked -= OnRunGame;
        _gameOver.RestartAction -= OnRunGame;

        _volcanoDisplayer.Fulled -= OnRunWin;
        _ground.Overheated -= OnRunGameOver;
    }

    private void Start()
    {
        RunTitle();
    }

    private void RunTitle()
    {
        Run(_title);
    }

    private void OnRunMenu()
    {
        Run(_menu);
    }

    private void OnRunGameOver()
    {
        Run(_gameOver);
        Time.timeScale = 0f;
    }

    private void OnRunWin()
    {
        Run(_win);
        Time.timeScale = 0f;
    }

    private void OnRunGame()
    {
        Run(_game);
        Time.timeScale = 1f;
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
