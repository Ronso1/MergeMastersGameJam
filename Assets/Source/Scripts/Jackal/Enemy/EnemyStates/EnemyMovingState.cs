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
        _enemy.Animator.SetBool("IsRun", true);
        _enemy.NavMeshAgent.isStopped = false;
    }

    public override void Exit()
    {
        _enemy.Animator.SetBool("IsRun", false);
        _enemy.NavMeshAgent.isStopped = true;
    }

    public override void LogicUpdate()
    {
        _diff = _enemy.Player.position - _enemy.transform.position;
        CheckStateChange();
        _enemy.NavMeshAgent.destination = _enemy.Player.position;
        float angle = Vector2.SignedAngle(Vector2.up, _diff);
        if (angle > 0)
            _enemy.transform.localScale = new Vector3(-1, 1, 1);
        else
            _enemy.transform.localScale = new Vector3(1, 1, 1);
    }

    public override void PhysicsUpdate()
    {
    }
}
