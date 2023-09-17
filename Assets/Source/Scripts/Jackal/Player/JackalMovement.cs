using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class JackalMovement : MonoBehaviour, Damagable
{
    private StateMachine _stateMachine;
    private IdleState _idleState;
    private MoveState _moveState;
    private HealthManager _healthManager;
    private int _level = 1;

    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Transform _gun;
    [SerializeField] private Slider _levelSlider;
    [SerializeField] private float _speed;
    [SerializeField] private int _maxHP;

    public HealthManager HealthManager { get { return _healthManager; } }
    public Animator Animator { get { return _animator; } }
    public Rigidbody2D Rigidbody { get { return _rigidbody; } }
    public SpriteRenderer SpriteRenderer { get { return _spriteRenderer; } }
    public Transform Gun { get { return _gun; } }
    public StateMachine StateMachine { get { return _stateMachine; } }
    public IdleState IdleState { get {  return _idleState; } }
    public MoveState MoveState { get { return _moveState; } }
    public float Speed { get { return _speed; } }

    private void Awake()
    {
        _stateMachine = new StateMachine();
        _idleState = new IdleState(_stateMachine, this);
        _moveState = new MoveState(_stateMachine, this);
        _healthManager = new HealthManager(_maxHP);

        _stateMachine.Initialize(_idleState);
    }

    private void Update()
    {
        _stateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        _stateMachine.CurrentState.PhysicsUpdate();
    }

    public void GetDamage(int damage)
    {
        _healthManager.GetDamage(damage);
    }

    public void AddLevelPoints()
    {
        _levelSlider.value += 0.1f / (_level + 3);
        if(_levelSlider.value >= 1)
        {
            _level++;
            _levelSlider.value = 0;
        }
    }
}
