using UnityEngine;

public class RewardCounter : MonoBehaviour
{
    [SerializeField] private PlayerInstantiator _instantiator;
    [SerializeField] private OldLevelCounter _levelCounter;
    [SerializeField] private StartButton _startButton;

    private float _realValue;
    private float _earnedValue;

    public float Value => _earnedValue;

    private void OnEnable()
    {
        if (_instantiator.Player != null)
            Calculate();

        _startButton.AddListener(SetValue);
    }

    private void OnDisable()
    {
        _startButton.RemoveListener(SetValue);
    }

    private void Calculate()
    {
        _earnedValue = _realValue + _instantiator.Player.Counter.CoinsNumber;
    }

    private void SetValue()
    {
        _realValue += _earnedValue;
        _earnedValue = _realValue;
    }
}
