using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _targetState;

    public Player Player { get; private set; }

    public State TargetState => _targetState;

    public bool NeedTransit { get; private set; }

    public void Initialize(Player player)
    {
        Player = player;
    }

    public void TurnOffNeedTransit()
    {
        NeedTransit = false;
    }

    protected void TurnOnNeedTransit()
    {
        NeedTransit = true;
    }
}