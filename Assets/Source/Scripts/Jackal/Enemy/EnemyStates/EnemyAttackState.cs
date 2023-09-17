using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : State
{
    private Enemy _enemy;
    private Vector2 _diff;
    private float _timer;
    private float _attackTime;

    public EnemyAttackState(StateMachine stateMachine, Enemy enemy) : base(stateMachine)
    {
        _enemy = enemy;
    }

    public override void CheckStateChange()
    {
        if (_diff.magnitude >= _enemy.EnemyConfig.AttackDistance || !_enemy.RaycastToPlayer(_diff))
            _stateMachine.ChangeState(_enemy.EnemyMovingState);

        if(_enemy.HealthManager.Health <= 0)
        {
            _stateMachine.ChangeState(_enemy.EnemyDieState);
        }
    }

    public override void Enter()
    {
        _timer = 100;
        if (_enemy.IsCar)
        {
            _attackTime = 3;
            return;
        }
        _enemy.Animator.SetBool("Attack", true);
        _attackTime = _enemy.Animator.GetCurrentAnimatorClipInfo(0).Length;
    }

    public override void Exit()
    {
        if (_enemy.IsCar)
            return;
        _enemy.Animator.SetBool("Attack", false);
    }

    public override void LogicUpdate()
    {
        _diff = _enemy.Player.position - _enemy.transform.position;
        CheckStateChange();
        if (_timer > _attackTime)
        {
            Shoot();
            _timer = 0;
        }
        _timer += Time.deltaTime;

        float angle = Vector2.SignedAngle(Vector2.up, _diff);
        if (_enemy.IsCar)
        {
            float angleForCar = Vector2.SignedAngle(Vector2.right, _diff);
            _enemy.transform.eulerAngles = new Vector3(0, 0, angleForCar);
            return;
        }
        if (angle > 0)
            _enemy.transform.localScale = new Vector3(-1, 1, 1);
        else
            _enemy.transform.localScale = new Vector3(1, 1, 1);
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
