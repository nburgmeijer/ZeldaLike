using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyState
{
    void EnterState(EnemyController enemy);
    void Update(EnemyController enemy);
    void OnCollisionEnter2D(EnemyController enemy);
}
