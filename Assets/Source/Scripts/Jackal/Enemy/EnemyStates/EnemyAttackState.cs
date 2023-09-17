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
    }

    public override void Enter()
    {
        _enemy.Animator.SetBool("Attack", true);
        _attackTime = _enemy.Animator.GetCurrentAnimatorClipInfo(0).Length;
        _timer = 100;
    }

    public override void Exit()
    {
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
