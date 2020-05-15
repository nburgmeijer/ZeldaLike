using UnityEngine;

public class LogChaseState : EnemyStateBase
{
    public override void EnterState(LogController enemy)
    {
        enemy.LogAnimator.SetBool("WakeUp", true);
    }

    public override void OnCollisionEnter(LogController enemy, Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enemy.TransitionToState(enemy.AttackState);
        }
    }

    public override void OnEnterTriggerEnter(LogController enemy, Collider2D collision)
    {
        if (collision.gameObject.CompareTag("HurtfulOther"))
        {
            enemy.TransitionToState(enemy.HurtState); 
        }
    }

    public override void FixedUpdate(LogController enemy)
    {
        if (!enemy.LogAnimator.GetCurrentAnimatorStateInfo(0).IsName("LogWaking")) 
        {
            Vector2 direction = (enemy.Target.transform.position - enemy.transform.position).normalized;
            enemy.LogAnimator.SetFloat("MoveX", direction.x);
            enemy.LogAnimator.SetFloat("MoveY", direction.y);
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, new Vector3(enemy.Target.position.x, enemy.Target.position.y, enemy.transform.position.z), enemy.MoveSpeed * Time.fixedDeltaTime);
        }
 
        if (Vector3.Distance(enemy.Target.position, enemy.transform.position) >= enemy.ChaseRadius)
        {
            enemy.TransitionToState(enemy.SleepState);
        }

    }

}
