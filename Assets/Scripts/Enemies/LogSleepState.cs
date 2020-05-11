using UnityEngine;

public class LogSleepState : IEnemyState
{
    public void EnterState(LogController enemy)
    {
        enemy.LogAnimator.SetBool("WakeUp", false);
    }

    public void OnCollisionEnter(LogController enemy, Collision2D collision)
    {
      
    }

    public void Update(LogController enemy)
    {
        
        if (Vector3.Distance(enemy.Target.position, enemy.transform.position) <= enemy.ChaseRadius)
        {
            enemy.TransitionToState(enemy.ChaseState);
        }
    }
}
