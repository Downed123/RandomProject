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
            
            GameObject bullet = ObjectPool.Instance.Activate(_ctx.BulletID, _ctx.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));

            bullet.GetComponent<BulletManager>().Target = "Enemy";
            bullet.GetComponent<BulletManager>().Shoot(Vector3.up);
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
