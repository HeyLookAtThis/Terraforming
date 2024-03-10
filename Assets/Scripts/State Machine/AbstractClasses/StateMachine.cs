using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private State _firstState;
    [SerializeField] private LevelGenerator _levelGenerator;

    private State _currentState;

    private void OnEnable()
    {
        _levelGenerator.Launched += SetDefaultState;
    }

    private void OnDisable()
    {
        _levelGenerator.Launched -= SetDefaultState;
    }

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
            _currentState.Enter();
    }

    private void Transit(State nextState)
    {
        if (_currentState != null)
            _currentState.Exit();

        Reset(nextState);
    }

    private void SetDefaultState(uint currentLevel)
    {
        Transit(_firstState);
    }
}