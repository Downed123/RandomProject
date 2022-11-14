using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : Billboard
{
    [SerializeField] private float _speed;

    private EnemyStateFactory _factory;
    private EnemyBaseState _currentState;

    public EnemyBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }

    private void Awake()
    {
        Init(gameObject);

        _factory = new EnemyStateFactory(this);
        _currentState = _factory.Normal();
        _currentState.EnterState();
    }

    private void Update()
    {
        _currentState.UpdateState();
    }

    protected override void SetAnimation()
    {
        _currentState.AnimateState();
    }
}
