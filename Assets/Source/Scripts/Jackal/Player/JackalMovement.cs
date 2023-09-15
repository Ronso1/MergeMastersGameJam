using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackalMovement : MonoBehaviour
{
    private StateMachine _stateMachine;
    private IdleState _idleState;
    private MoveState _moveState;

    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed;

    public Animator Animator { get { return _animator; } }
    public Rigidbody2D Rigidbody { get { return _rigidbody; } }
    public StateMachine StateMachine { get { return _stateMachine; } }
    public IdleState IdleState { get {  return _idleState; } }
    public MoveState MoveState { get { return _moveState; } }
    public float Speed { get { return _speed; } }

    private void Awake()
    {
        _stateMachine = new StateMachine();
        _idleState = new IdleState(_stateMachine, this);
        _moveState = new MoveState(_stateMachine, this);

        _stateMachine.Initialize(_idleState);
    }

    private void Update()
    {
        _stateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        _stateMachine.CurrentState.PhysicsUpdate();
    }
}
