using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : AttackHandler
{
    public Shoot(Transform current):base(current) {}

    public override IEnumerator Attack(int bulletID, float attackSpeed) {
        while(true)
        {
            GameObject newBullet = ObjectPool.Instance.Activate(bulletID, _current.position, Quaternion.Euler(new Vector3(0, 0, 0)));

            newBullet.GetComponent<BulletManager>().Target = "Player";
            newBullet.GetComponent<BulletManager>().Shoot(Vector3.down);

            yield return new WaitForSeconds(attackSpeed);
        }
    }
}
