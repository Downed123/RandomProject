using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerStateManager : Billboard
{
    [SerializeField] private float _speed;
    [SerializeField] private float _cooldown;
    [SerializeField] private int _bulletID;

    private PlayerInput _playerInput;
    private InputAction _movement;
    private InputAction _shoot;

    private PlayerBaseState _currentState;
    private PlayerStateFactory _factory;

    private bool _db = false;

    public Animator Animator { get { return _animator; } }

    public float MoveSpeed { get { return _speed; } }
    public float Cooldown { get { return _cooldown; } }
    public int BulletID { get { return _bulletID; } }

    public Vector2 MoveVector { get { return _movement.ReadValue<Vector2>(); } }
    public bool Shoot { get { return _shoot.triggered; } }

    public PlayerBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }

    public bool Db { get { return _db; } }

    private void Awake()
    {
        Init(gameObject);

        _playerInput = GetComponent<PlayerInput>();
        _movement = _playerInput.actions["Movement"];
        _shoot = _playerInput.actions["Shoot"];

        _factory = new PlayerStateFactory(this);
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

    public IEnumerator Debounce()
    {
        _db = true;

        yield return new WaitForSeconds(_cooldown);

        _db = false;
    }
}
