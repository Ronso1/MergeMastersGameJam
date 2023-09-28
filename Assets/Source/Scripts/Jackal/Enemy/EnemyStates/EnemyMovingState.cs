using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

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

        if (_enemy.HealthManager.Health <= 0)
            _stateMachine.ChangeState(_enemy.EnemyDieState);
    }

    public override void Enter()
    {
        if (_enemy.NavMeshAgent == null)
            return;
        if (!_enemy.IsCar)
            _enemy.Animator.SetBool("IsRun", true);
        _enemy.NavMeshAgent.isStopped = false;
    }

    public override void Exit()
    {
        if (_enemy.NavMeshAgent == null)
            return;
        if (!_enemy.IsCar)
            _enemy.Animator.SetBool("IsRun", false);
        _enemy.NavMeshAgent.isStopped = true;
    }

    public override void LogicUpdate()
    {
        _diff = _enemy.Player.position - _enemy.transform.position;
        CheckStateChange();
        if(_enemy.NavMeshAgent != null)
            _enemy.NavMeshAgent.destination = _enemy.Player.position;
        if (_enemy.IsCar || _enemy.NavMeshAgent == null)
        {
            float angleForCar = Vector2.SignedAngle(Vector2.right, _diff);
            _enemy.Gun.eulerAngles = new Vector3(0, 0, angleForCar);
            return;
        }
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
