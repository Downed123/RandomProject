using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Globals;

public class Horizontal : MovementHandler
{
    public Horizontal(Transform current):base(current) {}

    public override IEnumerator Move(EnemyStats enemyStats, float speed)
    {
        Vector3 newRange = new Vector3(enemyStats.range, 0, 0);
        Vector3 center = _current.position;

        while(true)
        {
            while(_current.position != (center + newRange))
            {
                _current.position = Vector3.MoveTowards(_current.position, center + newRange, Time.deltaTime * speed);
                yield return null;
            }

            newRange = new Vector3(-newRange.x, newRange.y, newRange.z);
        }
    }
}
