using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : AttackHandler
{
    public Target(Transform current):base(current) {}

    public override IEnumerator Attack(int bulletID, float attackSpeed) {
        Transform player = GameObject.Find("Spaceship").transform;

        Vector3 direction = (_current.position - player.position).normalized;

        Vector3 startPos = _current.position;

        ///while(true)
        //{
          //  _current.RotateAround(startPos + new Vector3(2, 0, 0), new Vector3(0, 0, 1), 2);
            //yield return null;
        //}
    }
}
