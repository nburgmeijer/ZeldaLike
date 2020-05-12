using DG.Tweening;
using UnityEngine;

public class LogAttackState : EnemyStateBase
{
    public override void EnterState(LogController enemy)
    {
        enemy.PlayerController.CanMove = false;
        enemy.LogRigidBody.velocity = Vector2.zero;
        Vector2 difference = enemy.Target.position - enemy.transform.position;
        difference = difference.normalized * enemy.Thrust;
        enemy.TargetRigidBody.DOMove(new Vector2(enemy.Target.position.x, enemy.Target.position.y) + difference, 0.3f).OnComplete(() => 
            {
                enemy.TransitionToState(enemy.ChaseState);
                enemy.PlayerController.CanMove = true;
            });
    }
}
