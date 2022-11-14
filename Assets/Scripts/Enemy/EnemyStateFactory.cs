using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateFactory
{
    private EnemyStateManager _ctx;

    public EnemyStateFactory(EnemyStateManager ctx)
    {
        _ctx = ctx;
    }

    public EnemyNormalState Normal()
    {
        return new EnemyNormalState(_ctx, this);
    }

    public EnemyAttackState Attack()
    {
        return new EnemyAttackState(_ctx, this);
    }
}
