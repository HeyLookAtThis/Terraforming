using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField] private Transition _transition;

    public virtual void Enter()
    {
        if(enabled == false)
        {
            enabled = true;
            _transition.enabled = true;
        }
    }

    public State GetNext()
    {
        if (_transition.NeedTransit)
            return _transition.TargetState;

        return null;
    }

    public void Exit()
    {
        if (enabled)
        {
            _transition.TurnOffNeedTransit();
            _transition.enabled = false;
            enabled = false;
        }
    }
}