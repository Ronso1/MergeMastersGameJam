using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    private JackalMovement _jackal;

    private Vector2 _input;

    public MoveState(StateMachine stateMachine, JackalMovement jackal) : base(stateMachine)
    {
        _jackal = jackal;
    }

    public override void CheckStateChange()
    {
        if(_input == Vector2.zero)
            _stateMachine.ChangeState(_jackal.IdleState);
    }

    public override void Enter()
    {

    }

    public override void Exit()
    {
        _jackal.Rigidbody.velocity = Vector2.zero;
    }

    public override void HandleInput()
    {
        _input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    public override void LogicUpdate()
    {
        HandleInput();
        CheckStateChange();
        float angle = Vector2.SignedAngle(Vector2.up, _input);
        if(_input != Vector2.zero)
        {
            _jackal.transform.rotation = Quaternion.Euler(0, 0, angle);
            if(angle > 0 && Mathf.Abs(angle) <= 180)
            {
                _jackal.transform.localScale = new Vector3(-1, 1, 1);
                _jackal.Gun.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                _jackal.transform.localScale = Vector3.one;
                _jackal.Gun.localScale = Vector3.one;
            }
        }
    }

    public override void PhysicsUpdate()
    {
        _jackal.Rigidbody.velocity = _input.normalized * _jackal.Speed;
    }
}
