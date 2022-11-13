using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootState : PlayerBaseState
{
    private bool _db = false;

    public PlayerShootState(PlayerStateManager context, PlayerStateFactory factory):base(context, factory) {}

    public override void EnterState()
    {
        if(!_ctx.Db)
        {
            _ctx.StartCoroutine(_ctx.Debounce());
            _ctx.Animator.Play("spaceshipShoot");

            GameObject bullet = Instantiate(_ctx.Bullet);

            bullet.transform.position = _ctx.transform.position;

            bullet.GetComponent<BulletManager>().Shoot();
        }
    }

    public override void UpdateState()
    {
        CheckSwitchStates();
    }

    public override void CheckSwitchStates()
    {
        SwitchState(_factory.Normal());
    }

    public override void AnimateState()
    {
        
    }
}
