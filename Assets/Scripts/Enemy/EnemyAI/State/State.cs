public abstract class State
{
    protected Enemy enemy;
    protected StateMachine stateMachine;

    protected State(Enemy enemy, StateMachine stateMachine)
    {
        this.enemy = enemy;
        this.stateMachine = stateMachine;
    }

    public virtual void Enter() { }

    public virtual void LogicUpdate() { }

    public virtual void Exit() { }
}
