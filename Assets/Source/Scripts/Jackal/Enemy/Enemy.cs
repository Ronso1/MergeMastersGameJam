using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, Damagable
{
    private StateMachine _stateMachine;
    private EnemyIdleState _enemyIdleState;
    private EnemyAttackState _enemyAttackState;
    private EnemyMovingState _enemyMovingState;
    private EnemyDieState _enemyDieState;
    private HealthManager _healthManager;

    private bool isStop = false;

    [HideInInspector] public Pool<Bullet> BulletPool;
    [HideInInspector] public Pool<Drop> DropPool;

    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Animator _animator;
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _shootPos;
    [SerializeField] private EnemyConfig _enemyConfig;
    [SerializeField] private ParticleSystem _deathParts;
    [SerializeField] private LayerMask _layerMaskForRaycast;
    [SerializeField] private int _hazard;
    [SerializeField] private int _maxHP;
    [SerializeField] private int _dropCount;
    [SerializeField] private bool _isCar;
    [SerializeField] private Transform _gun;


    public EnemyIdleState EnemyIdleState { get { return _enemyIdleState; } }
    public EnemyMovingState EnemyMovingState { get { return _enemyMovingState; } }
    public EnemyAttackState EnemyAttackState { get { return _enemyAttackState; } }
    public EnemyDieState EnemyDieState { get { return _enemyDieState; } }
    public HealthManager HealthManager { get { return _healthManager; } }
    public Rigidbody2D Rigidbody { get { return _rigidbody; } }
    public Animator Animator { get { return _animator; } }
    public NavMeshAgent NavMeshAgent { get { return _navMeshAgent; } }
    public Transform Player { get { return _player; } }
    public ParticleSystem DeathParts { get { return _deathParts; } }
    public Transform ShootPos { get { return _shootPos; } }
    public EnemyConfig EnemyConfig { get { return _enemyConfig; } }
    public int DropCount { get { return _dropCount; } }
    public int Hazard { get { return _hazard; } }
    public bool IsCar { get { return _isCar; } }
    public Transform Gun { get { return _gun; } }

    private void Awake()
    {
        if (_gun == null)
            _gun = transform;

        _stateMachine = new StateMachine();
        _enemyIdleState = new EnemyIdleState(_stateMachine, this);
        _enemyMovingState = new EnemyMovingState(_stateMachine, this);
        _enemyAttackState = new EnemyAttackState(_stateMachine, this);
        _enemyDieState = new EnemyDieState(_stateMachine, this);
        _healthManager = new HealthManager(_maxHP);

        _stateMachine.Initialize(_enemyIdleState);

        if (_enemyConfig.Speed == 0)
            return;

        _navMeshAgent.speed = _enemyConfig.Speed;
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updateUpAxis = false;
    }

    private void Update()
    {
        if (!isStop)
            _stateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        if (!isStop)
            _stateMachine.CurrentState.PhysicsUpdate();
    }

    public bool RaycastToPlayer(Vector2 diff)
    {
        var hit = Physics2D.Raycast(_shootPos.position, diff, _enemyConfig.AttackDistance, _layerMaskForRaycast);
        if (hit.collider != null && hit.collider.TryGetComponent(out JackalMovement _))
        {
            return true;
        }
        return false;
    }

    public void SetPlayer(Transform player)
    {
        _player = player;
    }

    public void GetDamage(int damage)
    {
        _healthManager.GetDamage(damage);
    }

    public void Reset()
    {
        _healthManager.Reset();
        _stateMachine.Initialize(_enemyIdleState);
    }

    public void Stop()
    {
        isStop = !isStop;
        if(_navMeshAgent != null && _navMeshAgent.hasPath)
            _navMeshAgent.isStopped = isStop;
    }
}
