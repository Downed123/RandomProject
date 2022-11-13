using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState: MonoBehaviour
{
    protected PlayerStateManager _ctx;
    protected PlayerStateFactory _factory;

    public PlayerBaseState(PlayerStateManager ctx, PlayerStateFactory factory)
    {
        _ctx = ctx;
        _factory = factory;
    }

    public abstract void EnterState();

    public abstract void UpdateState();

    public abstract void CheckSwitchStates();

    public abstract void AnimateState();

    protected void SwitchState(PlayerBaseState newState)
    {
        newState.EnterState();

        _ctx.CurrentState = newState;
    }
}
