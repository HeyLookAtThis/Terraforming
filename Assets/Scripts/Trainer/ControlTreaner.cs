using Agava.WebUtility;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class ControlTreaner : MonoBehaviour
{
    [SerializeField] private KeyboardTreaner _keyboard;
    [SerializeField] private MouseTreaner _mouse;

    private LevelBuilder _levelBuilder;
    private ITarget _chatacter;

    private Vector3 _startingPosition;
    private Vector3 _startingMousePosition;

    private bool _wasMoved;

    private UnityAction _completed;

    public event UnityAction Completed
    {
        add => _completed += value;
        remove => _completed -= value;
    }

    private void OnEnable()
    {
        if(_levelBuilder.Counter.IsFirstLevel == false)
            gameObject.SetActive(false);

        if (Device.IsMobile)
            Complete();

        _keyboard.gameObject.SetActive(true);
        _keyboard.Show();

        _startingPosition = _chatacter.Transform.position;
        _startingMousePosition = Input.mousePosition;

        _wasMoved = false;
    }

    private void Update()
    {
        if (_startingPosition != _chatacter.Transform.position && _wasMoved == false)
        {
            _wasMoved = true;
            _keyboard.Hide();

            _keyboard.Animation.OnComplete(() => SwitchKeyboardToMouse());
        }

        if (_mouse.gameObject.activeSelf && Input.GetMouseButtonDown(1) && Input.mousePosition != _startingMousePosition)
        {
            _mouse.Hide();
            _mouse.Animation.OnComplete(() => Complete());
        }
    }

    private void Complete()
    {
        _completed.Invoke();
        gameObject.SetActive(false);
    }

    private void SwitchKeyboardToMouse()
    {
        _keyboard.gameObject.SetActive(false);
        _mouse.gameObject.SetActive(true);
    }

    [Inject]
    private void Construct(ITarget target, LevelBuilder levelBuilder)
    {
        _chatacter = target;
        _levelBuilder = levelBuilder;
    }
}
