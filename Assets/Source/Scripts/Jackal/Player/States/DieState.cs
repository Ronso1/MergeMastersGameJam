using GamePush;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

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
        if ((int)GP_Player.GetScore() < CalculateDistance.playerScore)
        {
            GP_Player.SetScore(CalculateDistance.playerScore);
            GP_Player.Sync(true);
        }
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
