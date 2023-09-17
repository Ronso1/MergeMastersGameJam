using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.AI; 

public class Enemy : MonoBehaviour
{
    private StateMachine _stateMachine;
    private EnemyIdleState _enemyIdleState;
    private EnemyAttackState _enemyAttackState;
    private EnemyMovingState _enemyMovingState;
    private HealthManager _healthManager;

    [HideInInspector] public Pool<Bullet> BulletPool;

    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Animator _animator;
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _shootPos;
    [SerializeField] private EnemyConfig _enemyConfig;
    [SerializeField] private LayerMask _layerMaskForRaycast;
    [SerializeField] private int _hazard;
    [SerializeField] private int _maxHP;
    [SerializeField] private bool _isCar;

    public EnemyIdleState EnemyIdleState { get { return _enemyIdleState; } }
    public EnemyMovingState EnemyMovingState { get { return _enemyMovingState; } }
    public EnemyAttackState EnemyAttackState { get { return _enemyAttackState; } }
    public HealthManager HealthManager { get { return _healthManager; } }
    public Rigidbody2D Rigidbody { get { return _rigidbody; } }
    public Animator Animator { get { return _animator; } }
    public NavMeshAgent NavMeshAgent { get { return _navMeshAgent; } }
    public Transform Player { get { return _player; } }
    public Transform ShootPos { get { return _shootPos; } }
    public EnemyConfig EnemyConfig { get { return _enemyConfig; } }
    public int Hazard { get { return _hazard; } }
    public bool IsCar { get { return _isCar; } }

    private void Awake()
    {
        _stateMachine = new StateMachine();
        _enemyIdleState = new EnemyIdleState(_stateMachine, this);
        _enemyMovingState = new EnemyMovingState(_stateMachine, this);
        _enemyAttackState = new EnemyAttackState(_stateMachine, this);
        _healthManager = new HealthManager(_maxHP);

        _navMeshAgent.speed = _enemyConfig.Speed;
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updateUpAxis = false;

        _stateMachine.Initialize(_enemyIdleState);
    }

    private void Update()
    {
        _stateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        _stateMachine.CurrentState.PhysicsUpdate();
    }

    public bool RaycastToPlayer(Vector2 diff)
    {
        var hit = Physics2D.Raycast(_shootPos.position, diff, _enemyConfig.AttackDistance, _layerMaskForRaycast);
        if(hit.collider != null && hit.collider.TryGetComponent(out JackalMovement _))
        {
            return true;
        }
        return false;
    }

    public void SetPlayer(Transform player)
    {
        _player = player;
    }
}
