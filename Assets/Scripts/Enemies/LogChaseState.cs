using UnityEngine;

public class LogChaseState : IEnemyState
{
    public void EnterState(LogController enemy)
    {
        enemy.LogAnimator.SetBool("WakeUp", true);
    }

    public void OnCollisionEnter(LogController enemy, Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enemy.TransitionToState(enemy.AttackState);
        }
    }

    public void Update(LogController enemy)
    {
        if (!enemy.LogAnimator.GetCurrentAnimatorStateInfo(0).IsName("LogWaking")) 
        {
            Vector2 direction = (enemy.Target.transform.position - enemy.transform.position).normalized;
            enemy.LogAnimator.SetFloat("MoveX", direction.x);
            enemy.LogAnimator.SetFloat("MoveY", direction.y);
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, enemy.Target.position, enemy.MoveSpeed * Time.fixedDeltaTime);
        }
 
        if (Vector3.Distance(enemy.Target.position, enemy.transform.position) >= enemy.ChaseRadius)
        {
            enemy.TransitionToState(enemy.SleepState);
        }

    }

}
