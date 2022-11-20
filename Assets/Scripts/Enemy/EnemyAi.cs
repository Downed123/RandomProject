using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    private Transform _current;

    private string _movementType;
    private string _attackType;

    public EnemyAi(Transform current, string movementType, string attackType)
    {
        _current = current;
        _movementType = movementType;
        _attackType = attackType;
    }

    public IEnumerator Movement(Vector3 target, float maxDistanceDelta)
    {
        while(_current.position != target)
        {
            _current.position = Vector3.MoveTowards(_current.position, target, maxDistanceDelta);
            yield return null;
        }

        _current.GetComponent<EnemyController>().StartCoroutine(Movement(new Vector3(-target.x, target.y, target.z), maxDistanceDelta));
    }

    public IEnumerator Shoot(int bulletID) {
        while(true)
        {
            GameObject newBullet = ObjectPool.Instance.Activate(bulletID, _current.position, Quaternion.Euler(new Vector3(0, 0, 0)));

            newBullet.GetComponent<BulletManager>().Target = "Player";
            newBullet.GetComponent<BulletManager>().Shoot(Vector3.down);

            yield return new WaitForSeconds(0.5f);
        }
    }
}
