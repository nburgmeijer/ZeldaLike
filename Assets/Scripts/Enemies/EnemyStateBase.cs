﻿using UnityEngine;

public abstract class EnemyStateBase
{
    public virtual void EnterState(LogController enemy) { }
    public virtual void FixedUpdate(LogController enemy) { }
    public virtual void OnCollisionEnter(LogController enemy, Collision2D collision) { }
    public virtual void OnEnterTriggerEnter(LogController enemy, Collider2D collision) { }
}
