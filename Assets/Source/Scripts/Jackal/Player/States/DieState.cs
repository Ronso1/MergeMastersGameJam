using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DieState : State
{
    private JackalMovement _jackal;

    public DieState(StateMachine stateMachine, JackalMovement jackal) : base(stateMachine)
    {
        _jackal = jackal;
    }

    public override void CheckStateChange()
    {
        
    }

    public override void Enter()
    {
        _jackal.DiePanel.SetActive(true);
    }

    public override void Exit()
    {

    }

    public override void HandleInput()
    {
    }

    public override void LogicUpdate()
    {
    }

    public override void PhysicsUpdate()
    {

    }
}
