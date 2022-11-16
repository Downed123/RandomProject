using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private MovementType _movementType;
    [SerializeField] private AttackType _attackType;

    private EnemyAi _enemyAi;

    enum MovementType
    {
        Horizontal
    }

    enum AttackType
    {
        Shoot
    }

    private void Awake()
    {
        _enemyAi = new EnemyAi(gameObject);
    }

    public void StartAi()
    {
        StartCoroutine(Movement(transform, transform.position + new Vector3(5f, 0f, 0f), Time.deltaTime * 5f));
        StartCoroutine(Shoot());
    }

    private IEnumerator Movement(Transform current, Vector3 target, float maxDistanceDelta)
    {
        while(current.position != target)
        {
            current.position = Vector3.MoveTowards(current.position, target, maxDistanceDelta);
            yield return null;
        }

        StartCoroutine(Movement(current, new Vector3(-target.x, target.y, target.z), maxDistanceDelta));
    }

    private IEnumerator Shoot() {
        while(true)
        {
            GameObject bullet = Instantiate(_bullet);

            bullet.transform.position = transform.position;

            bullet.GetComponent<BulletManager>().Shoot();

            yield return new WaitForSeconds(0.5f);
        }
    }
}
