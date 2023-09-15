using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovingState : State
{
    private Enemy _enemy;
    private Vector2 _diff;

    public EnemyMovingState(StateMachine stateMachine, Enemy enemy) : base(stateMachine)
    {
        _enemy = enemy;
    }

    public override void CheckStateChange()
    {
        if (_diff.magnitude <= _enemy.EnemyConfig.AttackDistance && _enemy.RaycastToPlayer(_diff))
            _stateMachine.ChangeState(_enemy.EnemyAttackState);
        else if(_diff.magnitude > _enemy.EnemyConfig.IdleDistance)
            _stateMachine.ChangeState(_enemy.EnemyIdleState);
    }

    public override void Enter()
    {
        _enemy.NavMeshAgent.isStopped = false;
    }

    public override void Exit()
    {
        _enemy.NavMeshAgent.isStopped = true;
        Debug.Log("gasga");
    }

    public override void LogicUpdate()
    {
        _diff = _enemy.Player.position - _enemy.transform.position;
        CheckStateChange();
        _enemy.NavMeshAgent.destination = _enemy.Player.position;
    }

    public override void PhysicsUpdate()
    {
    }
}
