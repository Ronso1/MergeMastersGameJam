using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    private JackalMovement _jackal;

    private Vector2 _input;

    public IdleState(StateMachine stateMachine, JackalMovement jackal) : base(stateMachine)
    {
        _jackal = jackal;
    }

    public override void CheckStateChange()
    {
        if(_input != Vector2.zero)
            _stateMachine.ChangeState(_jackal.MoveState);

        if (_jackal.HealthManager.Health <= 0)
        {
            _stateMachine.ChangeState(_jackal.DieState);
        }
    }

    public override void Enter()
    {

    }

    public override void Exit()
    {
        
    }

    public override void HandleInput()
    {
        _input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) + new Vector2(_jackal.Joystick.Horizontal, _jackal.Joystick.Vertical);
    }

    public override void LogicUpdate()
    {
        HandleInput();
        CheckStateChange();
    }

    public override void PhysicsUpdate()
    {
        
    }
}
