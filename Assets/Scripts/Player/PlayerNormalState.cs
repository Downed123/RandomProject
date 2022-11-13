using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNormalState : PlayerBaseState
{
    public PlayerNormalState(PlayerStateManager context, PlayerStateFactory factory):base(context, factory) {}

    public override void EnterState()
    {
        
    }

    public override void UpdateState()
    {
        Vector2 moveVector = _ctx.MoveVector * Time.deltaTime * _ctx.MoveSpeed;

        _ctx.transform.Translate(moveVector);

        CheckSwitchStates();
    }

    public override void CheckSwitchStates()
    {
        if(_ctx.Shoot)
        {
            SwitchState(_factory.Shoot());
        }
    }

    public override void AnimateState()
    {
        _ctx.Animator.Play("spaceshipNormal");
    }
}
