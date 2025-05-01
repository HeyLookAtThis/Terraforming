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
    private bool _wasCompleted;

    private UnityAction _completed;

    public event UnityAction Completed
    {
        add => _completed += value;
        remove => _completed -= value;
    }

    private void OnEnable()
    {
        if (_levelBuilder.Counter.IsFirstLevel && Device.IsMobile == false)
        {
            _wasCompleted = false;

            _keyboard.gameObject.SetActive(true);
            _keyboard.Show();

            SetStartingCharacterPosition();
            _startingMousePosition = Input.mousePosition;

            _wasMoved = false;
        }
    }

    private void Update()
    {
        if (Device.IsMobile || _wasCompleted)
            return;

        if (IsCharacterMoved() && _wasMoved == false)
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

        _keyboard.gameObject.SetActive(false);
        _mouse.gameObject.SetActive(false);

        _wasCompleted = true;
    }

    private void SwitchKeyboardToMouse()
    {
        _keyboard.gameObject.SetActive(false);
        _mouse.gameObject.SetActive(true);
    }

    private void SetStartingCharacterPosition()
    {
        _startingPosition.y = 0;
        _startingPosition.x = _chatacter.Transform.position.x;
        _startingPosition.z = _chatacter.Transform.position.z;
    }

    private bool IsCharacterMoved()
    {
        if(_startingPosition.x == _chatacter.Transform.position.x && _startingPosition.z == _chatacter.Transform.position.z)
            return false;

        return true;
    }

    [Inject]
    private void Construct(ITarget target, LevelBuilder levelBuilder)
    {
        _chatacter = target;
        _levelBuilder = levelBuilder;
    }
}
