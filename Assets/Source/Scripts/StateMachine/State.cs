public abstract class State
{
    public StateMachine _stateMachine;

    public State(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public abstract void Enter();
    public abstract void HandleInput();

    public abstract void LogicUpdate();

    public abstract void PhysicsUpdate();

    public abstract void CheckStateChange();

    public abstract void Exit();
}
