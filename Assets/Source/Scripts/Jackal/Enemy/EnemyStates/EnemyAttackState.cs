using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : State
{
    private Enemy _enemy;
    private Vector2 _diff;
    private float _timer;

    public EnemyAttackState(StateMachine stateMachine, Enemy enemy) : base(stateMachine)
    {
        _enemy = enemy;
    }

    public override void CheckStateChange()
    {
        if (_diff.magnitude >= _enemy.EnemyConfig.AttackDistance || !_enemy.RaycastToPlayer(_diff))
            _stateMachine.ChangeState(_enemy.EnemyMovingState);
    }

    public override void Enter()
    {
    }

    public override void Exit()
    {
    }

    public override void LogicUpdate()
    {
        _diff = _enemy.Player.position - _enemy.transform.position;
        CheckStateChange();
        if (_timer > _enemy.EnemyConfig.AttackTime)
        {
            Shoot();
            _timer = 0;
        }
        _timer += Time.deltaTime;
    }

    public override void PhysicsUpdate()
    {
    }

    private void Shoot()
    {
        var bullet = _enemy.BulletPool.GetElement();
        bullet.Reset();
        bullet.transform.position = _enemy.ShootPos.position;
        bullet._directon = _diff.normalized;
    }
}