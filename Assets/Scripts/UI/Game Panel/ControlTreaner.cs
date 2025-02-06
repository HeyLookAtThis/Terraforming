using Agava.WebUtility;
using DG.Tweening;
using UnityEngine;
using Zenject;

public class ControlTreaner : MonoBehaviour
{
    [SerializeField] private KeyboardTreaner _keyboard;
    [SerializeField] private MouseTreaner _mouse;

    private ITarget _chatacter;

    private Vector3 _startingPosition;
    private Vector3 _startingMousePosition;

    private bool _wasMoved;

    private void Awake()
    {
        if (Device.IsMobile)
            gameObject.SetActive(false);
    }

    private void OnEnable()
    {
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
            _mouse.Animation.OnComplete(() => gameObject.SetActive(false));
        }
    }

    [Inject]
    private void Construct(ITarget target) => _chatacter = target;
    private void SwitchKeyboardToMouse()
    {
        _keyboard.gameObject.SetActive(false);
        _mouse.gameObject.SetActive(true);
    }
}
