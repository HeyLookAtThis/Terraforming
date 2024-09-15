using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningState : MovementState
{
    public RunningState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Data.Speed = 4;
    }

    public override void Update()
    {
        base.Update();

        if (IsInputDirectionZero())
            StateSwitcher.SwitchState<IdilingState>();
    }
}
