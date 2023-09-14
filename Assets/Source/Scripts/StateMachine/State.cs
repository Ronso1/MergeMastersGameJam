public abstract class State
{
    private StateMachine machine;

    public State(StateMachine stateMachine)
    {
        machine = stateMachine;
    }

    public virtual void Enter()
    {

    }

    public virtual void HandleInput()
    {

    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {

    }

    public virtual void CheckStateChange()
    {

    }

    public virtual void Exit()
    {

    }
}
