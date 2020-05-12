using UnityEngine;

public class LogSleepState : EnemyStateBase
{
    public override void EnterState(LogController enemy)
    {
        enemy.LogAnimator.SetBool("WakeUp", false);
    }

    public override void FixedUpdate(LogController enemy)
    {
        if (Vector3.Distance(enemy.Target.position, enemy.transform.position) <= enemy.ChaseRadius)
        {
            enemy.TransitionToState(enemy.ChaseState);
        }
    }
}
