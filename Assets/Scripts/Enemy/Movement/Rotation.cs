using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Globals;

public class Rotation : MovementHandler
{
    public Rotation(Transform current):base(current) {}

    public override IEnumerator Move(EnemyStats enemyStats, float speed)
    {
        while(true)
        {
            _current.RotateAround(enemyStats.center, Vector3.forward, speed);
            _current.rotation = Quaternion.identity;
            yield return null;
        }
    }
}
