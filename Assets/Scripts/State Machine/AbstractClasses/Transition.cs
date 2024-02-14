using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _targetState;

    public State TargetState => _targetState;

    public bool NeedTransit { get; private set; }

    public void TurnOffNeedTransit()
    {
        NeedTransit = false;
    }

    protected void TurnOnNeedTransit()
    {
        NeedTransit = true;
    }
}