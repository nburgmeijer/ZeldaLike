using UnityEngine;

public interface IEnemyState
{
    void EnterState(LogController enemy);
    void Update(LogController enemy);
    void OnCollisionEnter(LogController enemy, Collision2D collision);
}
