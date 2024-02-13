using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private State _firstState;
    [SerializeField] private Cloud _cloud;
    [SerializeField] private Player _player;

    private State _currentState;

    private void Start()
    {
        Reset(_firstState);
    }

    private void Update()
    {
        if (_currentState == null)
            return;

        var nextState = _currentState.GetNext();

        if (nextState != null)
            Transit(nextState);
    }

    public void Reset(State state)
    {
        _currentState = state;

        if (_currentState != null)
            _currentState.Enter(_player, _cloud);
    }

    private void Transit(State nextState)
    {
        if (_currentState != null)
            _currentState.Exit();

        Reset(nextState);
    }
}