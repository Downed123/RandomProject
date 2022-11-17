using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private MovementType _movementType;
    [SerializeField] private AttackType _attackType;
    [SerializeField] private float _speed;

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
        string movement = "";
        string attack = "";

       switch(_movementType)
       {
        case MovementType.Horizontal:
            movement = "Horizontal";
            break;
       }

        switch(_attackType)
       {
        case AttackType.Shoot:
            attack = "Shoot";
            break;
       }

        _enemyAi = new EnemyAi(transform, movement, attack);
    }

    public void StartAi()
    {
        StartCoroutine(_enemyAi.Movement(transform.position + new Vector3(5f, 0f, 0f), Time.deltaTime * _speed));
        StartCoroutine(_enemyAi.Shoot(_bullet));
    }
}
