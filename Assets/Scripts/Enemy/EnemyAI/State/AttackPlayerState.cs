public class AttackPlayerState : State
{
    public AttackPlayerState(Enemy enemy, StateMachine stateMachine) : base(enemy, stateMachine) { }

    public override void Enter()
    {
        enemy.SetAnimationBool("Attack", true);
    }

    public override void LogicUpdate()
    {
        enemy.LookAtTarget(enemy.AttackTarget);
        if (enemy.AttackTarget == null || enemy.IsPlayerOutRange())
        {
            stateMachine.ChangeState(enemy.RunToHouse);
        }
    }

    public override void Exit()
    {
        enemy.SetAnimationBool("Attack", false);   
    }
}
