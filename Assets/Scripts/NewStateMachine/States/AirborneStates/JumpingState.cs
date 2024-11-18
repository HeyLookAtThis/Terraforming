using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingState : AirborneState
{
    public JumpingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
    }
}
