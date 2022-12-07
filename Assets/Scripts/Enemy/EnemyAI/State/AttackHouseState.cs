public class AttackHouseState : State
{
    public AttackHouseState(Enemy enemy, StateMachine stateMachine) : base(enemy, stateMachine) { }

    public override void Enter()
    {      
        enemy.SetAnimationBool("Attack", true);
    }

    public override void LogicUpdate()
    {
        if (enemy.IsHouseDestoyed())
            stateMachine.ChangeState(enemy.RunToHouse);
        enemy.LookAtTarget(enemy.AttackTarget);
        if(enemy.CheckPlayerAround())
            stateMachine.ChangeState(enemy.AttackPlayer); 
    }

    public override void Exit()
    {
        enemy.SetAnimationBool("Attack", false); 
    }
}
