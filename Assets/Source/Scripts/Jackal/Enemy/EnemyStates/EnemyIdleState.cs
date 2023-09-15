using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : State
{
    private Enemy _enemy;
    private float _diff;

    public EnemyIdleState(StateMachine stateMachine, Enemy enemy) : base(stateMachine)
    {
        _enemy = enemy;
    }

    public override void CheckStateChange()
    {
        if (_diff <= _enemy.EnemyConfig.IdleDistance)
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
        _diff = (_enemy.Player.position - _enemy.transform.position).magnitude;
        CheckStateChange();
    }

    public override void PhysicsUpdate()
    {
    }
}
