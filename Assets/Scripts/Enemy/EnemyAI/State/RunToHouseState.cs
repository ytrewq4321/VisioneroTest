public class RunToHouseState : State
{
    public RunToHouseState(Enemy enemy, StateMachine stateMachine) : base(enemy, stateMachine) { }
    public override void Enter()
    {
        enemy.ResumeMovement();
        enemy.SetHouseTarget();
    }

    public override void LogicUpdate()
    {
        if(enemy.CheckPlayerAround())
            stateMachine.ChangeState(enemy.AttackPlayer);
        else if(enemy.CheckHouseAround())
            stateMachine.ChangeState(enemy.AttackHouse);
    }

    public override void Exit()
    {
        enemy.StopMovement();
    }
}
