using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using static Cinemachine.DocumentationSortingAttribute;

public class JackalMovement : MonoBehaviour, Damagable
{
    private StateMachine _stateMachine;
    private IdleState _idleState;
    private MoveState _moveState;
    private DieState _dieState;
    private HealthManager _healthManager;
    private int _level = 1;

    public UnityAction StopGame;

    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Transform _gun;
    [SerializeField] private Slider _levelSlider;
    [SerializeField] private GameObject _levelUpPanel;
    [SerializeField] private GameObject _diePanel;
    [SerializeField] private float _speed;
    [SerializeField] private int _maxHP;

    private bool isStop = false;

    public HealthManager HealthManager { get { return _healthManager; } }
    public Animator Animator { get { return _animator; } }
    public Rigidbody2D Rigidbody { get { return _rigidbody; } }
    public SpriteRenderer SpriteRenderer { get { return _spriteRenderer; } }
    public Transform Gun { get { return _gun; } }
    public StateMachine StateMachine { get { return _stateMachine; } }
    public IdleState IdleState { get {  return _idleState; } }
    public DieState DieState { get { return _dieState; } }
    public MoveState MoveState { get { return _moveState; } }
    public GameObject DiePanel { get { return _diePanel; } }
    public float Speed { get { return _speed; } }
    public bool IsStop { get { return isStop; } }

    private void Awake()
    {
        _stateMachine = new StateMachine();
        _idleState = new IdleState(_stateMachine, this);
        _moveState = new MoveState(_stateMachine, this);
        _dieState = new DieState(_stateMachine, this);
        _healthManager = new HealthManager(_maxHP);

        _stateMachine.Initialize(_idleState);
    }

    private void Update()
    {
        if(!isStop)
            _stateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        if (!isStop)
            _stateMachine.CurrentState.PhysicsUpdate();
    }

    public void GetDamage(int damage)
    {
        if(!isStop)
            _healthManager.GetDamage(damage);
    }

    private void OnEnable()
    {
        StopGame += Stop;
    }

    private void OnDisable()
    {
        StopGame -= Stop;
    }

    public void AddLevelPoints()
    {
        _levelSlider.value += 0.1f / (_level + 3);
        if(_levelSlider.value >= 1)
        {
            StopGame?.Invoke();
            _levelUpPanel.SetActive(true);
            _level++;
            _levelSlider.value = 0;
        }
    }

    void Stop()
    {
        isStop = !isStop;
    }

    public void AddSpeed(float speed)
    {
        _speed += speed;
    }
}
