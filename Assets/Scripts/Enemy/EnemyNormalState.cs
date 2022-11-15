using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNormalState : EnemyBaseState
{
    public EnemyNormalState(EnemyStateManager ctx, EnemyStateFactory factory):base(ctx, factory) {}

    public override void EnterState()
    {

    }

    public override void UpdateState()
    {


        CheckSwitchStates();
    }

    public override void CheckSwitchStates()
    {
        Debug.Log(_ctx.Shoot);
        if(_ctx.Shoot)
        {
            SwitchState(_factory.Attack());
        }
    }

    public override void AnimateState()
    {

    }
}
