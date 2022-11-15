using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : Billboard
{
    [SerializeField] private float _speed;
    [SerializeField] private float _cooldown;

    private EnemyStateFactory _factory;
    private EnemyBaseState _currentState;

    private bool _shoot = false;

    public EnemyBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }

    public bool Shoot { get { return _shoot; } }

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
