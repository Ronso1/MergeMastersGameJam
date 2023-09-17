using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDieState : State
{
    private Enemy _enemy;
    private float _timer = 0;
    public EnemyDieState(StateMachine stateMachine, Enemy enemy) : base(stateMachine)
    {
        _enemy = enemy;
    }

    public override void CheckStateChange()
    {
    }

    public override void Enter()
    {
        for (int i = 0; i < _enemy.DropCount; i++)
        {
            Drop drop = _enemy.DropPool.GetElement();
            drop.Reset();
            drop.transform.position = (Vector2)_enemy.transform.position + new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f));
            drop.Player = _enemy.Player;
        }
        _enemy.DeathParts.Play();
    }

    public override void Exit()
    {
    }

    public override void LogicUpdate()
    {
        if(_timer >= (_enemy.DeathParts.totalTime*2))
        {
            _enemy.gameObject.SetActive(false);
            _timer = 0;
        }
        _timer += Time.deltaTime;
    }

    public override void PhysicsUpdate()
    {
    }

}
