using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField] private Transition _transition;

    protected Cloud cloud;

    //protected float speed;
    protected Vector3 targetPosition;
    protected Vector3 positionIndent;

    private float _speedMultiplier = 5;

    protected Player Target { get; private set; }

    private void Start()
    {
        //speed = Target.Speed * _speedMultiplier;
    }

    public virtual void Enter(Player player, Cloud cloud)
    {
        if (enabled == false)
        {
            enabled = true;
            Target = player;
            this.cloud = cloud;

            _transition.enabled = true;
            _transition.Initialize(player);
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