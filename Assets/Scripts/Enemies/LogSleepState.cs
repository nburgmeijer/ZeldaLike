using UnityEngine;

public class LogSleepState : EnemyStateBase
{
    public override void EnterState(LogController enemy)
    {
        enemy.LogAnimator.SetBool("WakeUp", false);
    }

    public override void FixedUpdate(LogController enemy)
    {
        if (Vector3.Distance(enemy.Target.position, enemy.transform.position) <= enemy.LogStats.ChaseRadius)
        {
            enemy.TransitionToState(enemy.ChaseState);
        }
    }

    public override void OnEnterTriggerEnter(LogController enemy, Collider2D collision)
    {
        if (collision.gameObject.CompareTag("HurtfulOther"))
        {
            enemy.CurrentHealth -= enemy.PlayerController.SwordDamage;
            enemy.TransitionToState(enemy.HurtState);
        }
    }
}
