using UnityEngine;

public class PanelSwitcher : MonoBehaviour
{
    [SerializeField] private Ground _ground;
    [SerializeField] private VolcanoesDisplayer _volcanoDisplayer;

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
    }

    private void Start()
    {
        StartGame();
    }

    private void OnEnable()
    {
        _ground.Overheated += OnLossLevel;
        _gameOver.RestartAction += OnStartLevel;
        _title.Clicked += OnStartLevel;
        _volcanoDisplayer.Fulled += OnWinLevel;
        _win.RestartButtonClicked += OnStartLevel;
        _win.ContinueButtonClicked += OnStartLevel;
    }

    private void OnDisable()
    {
        _ground.Overheated -= OnLossLevel;
        _gameOver.RestartAction -= OnStartLevel;
        _title.Clicked -= OnStartLevel;
        _volcanoDisplayer.Fulled -= OnWinLevel;
        _win.RestartButtonClicked -= OnStartLevel;
        _win.ContinueButtonClicked -= OnStartLevel;
    }

    private void StartGame()
    {
        _title.gameObject.SetActive(true);
        _game.gameObject.SetActive(false);
        _gameOver.gameObject.SetActive(false);
        _win.gameObject.SetActive(false);
    }

    private void OnLossLevel()
    {
        _game.gameObject.SetActive(false);
        _gameOver.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    private void OnWinLevel()
    {
        _game.gameObject.SetActive(false);
        _win.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    private void OnStartLevel()
    {
        _game.gameObject.SetActive(true);
        _gameOver.gameObject.SetActive(false);
        _title.gameObject.SetActive(false);
        _win.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
