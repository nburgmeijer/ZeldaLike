using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class LogHurtState : EnemyStateBase
{
    public override void EnterState(LogController enemy)
    {
        enemy.LogRigidBody.velocity = Vector2.zero;
        Vector2 difference = enemy.transform.position - enemy.Target.position;
        difference = difference.normalized * enemy.Thrust;
        enemy.LogRigidBody.DOMove(new Vector2(enemy.transform.position.x, enemy.transform.position.y) + difference, 0.3f).OnComplete(() =>
        {
            enemy.TransitionToState(enemy.LastState);
        });
    }
}
