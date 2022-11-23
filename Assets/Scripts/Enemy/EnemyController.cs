using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int _bulletID;
    [SerializeField] private MovementType _movement;
    [SerializeField] private AttackType _attack;
    [SerializeField] private float _speed;
    [SerializeField] private float _attackSpeed;

    private MovementHandler _movementHandler;
    private AttackHandler _attackHandler;

    enum MovementType
    {
        Idle,
        Horizontal
    }

    enum AttackType
    {
        Shoot,
        Target
    }

    private void Awake()
    {
       switch(_movement) {
            case MovementType.Horizontal:
                _movementHandler = new Horizontal(transform);
                break;
       }

       switch(_attack) {
            case AttackType.Shoot:
                _attackHandler = new Shoot(transform);
                break;
            case AttackType.Target:
                _attackHandler = new Target(transform);
                break;
       }
    }

    public void StartAi(float range)
    {
        if(_movement != MovementType.Idle)
        {
            StartCoroutine(_movementHandler.Move(new Vector3(range, 0f, 0f), _speed));
        }

        StartCoroutine(_attackHandler.Attack(_bulletID, _attackSpeed));
    }
}
