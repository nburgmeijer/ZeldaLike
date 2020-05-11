using DG.Tweening;
using UnityEngine;

public class LogAttackState : IEnemyState
{
    public void EnterState(LogController enemy)
    {
        enemy.PlayerController.CanMove = false;
        enemy.LogRigidBody.velocity = Vector2.zero;
        Vector3 difference = enemy.Target.position - enemy.transform.position;
        difference = difference.normalized * enemy.Thrust;
        enemy.TargetRigidBody.DOMove(enemy.Target.position + difference, 0.3f).OnComplete(() => 
            {
                enemy.TransitionToState(enemy.ChaseState);
                enemy.PlayerController.CanMove = true;
            });
    }

    public void OnCollisionEnter(LogController enemy, Collision2D collision)
    {
       
    }

    public void Update(LogController enemy)
    {
        
    }

}
