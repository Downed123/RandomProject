using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Globals;

public abstract class MovementHandler
{
    protected Transform _current;

    public MovementHandler(Transform current)
    {
        _current = current;
    }

    public abstract IEnumerator Move(EnemyStats enemyStats, float speed);
}
