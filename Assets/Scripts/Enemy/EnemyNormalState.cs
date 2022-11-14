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
        Debug.Log("update");
        _ctx.transform.position = Vector3.MoveTowards(_ctx.transform.position, new Vector3(0, -4, 0), 5f * Time.deltaTime);
    }

    public override void CheckSwitchStates()
    {

    }

    public override void AnimateState()
    {

    }
}
