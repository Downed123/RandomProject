using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseState : MonoBehaviour
{
    protected EnemyStateManager _ctx;
    protected EnemyStateFactory _factory;

    public EnemyBaseState(EnemyStateManager ctx, EnemyStateFactory factory)
    {
        _ctx = ctx;
        _factory = factory;
    }

    public abstract void EnterState();

    public abstract void UpdateState();

    public abstract void CheckSwitchStates();

    public abstract void AnimateState();

    protected void SwitchState(EnemyBaseState newState)
    {
        newState.EnterState();

        _ctx.CurrentState = newState;
    }
}
