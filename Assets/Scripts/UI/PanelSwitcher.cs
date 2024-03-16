using UnityEngine;

public class PanelSwitcher : MonoBehaviour
{
    [SerializeField] private Ground _ground;
    [SerializeField] private VolcanoesDisplayer _volcanoDisplayer;

    private Panel[] _panels;

    private GamePanel _game;
    private GameOverPanel _gameOver;
    private TitlePanel _title;
    private WinPanel _win;

    private void Awake()
    {
        _gameOver = GetComponentInChildren<GameOverPanel>();
        _game = GetComponentInChildren<GamePanel>();
        _title = GetComponentInChildren<TitlePanel>();
        _win = GetComponentInChildren<WinPanel>();

        InitializePanels();
    }

    private void Start()
    {
        RunTitle();
    }

    private void OnEnable()
    {
        _ground.Overheated += OnRunGameOver;
        _gameOver.RestartAction += OnRunGame;
        _title.Clicked += OnRunGame;
        _volcanoDisplayer.Fulled += OnRunWin;
        _win.RestartButtonClicked += OnRunGame;
        _win.ContinueButtonClicked += OnRunGame;
    }

    private void OnDisable()
    {
        _ground.Overheated -= OnRunGameOver;
        _gameOver.RestartAction -= OnRunGame;
        _title.Clicked -= OnRunGame;
        _volcanoDisplayer.Fulled -= OnRunWin;
        _win.RestartButtonClicked -= OnRunGame;
        _win.ContinueButtonClicked -= OnRunGame;
    }

    private void InitializePanels()
    {
        _panels = new Panel[] { _title, _game, _win, _gameOver };
    }

    private void RunTitle()
    {
        Run(_title);
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
