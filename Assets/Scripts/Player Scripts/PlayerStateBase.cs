using UnityEngine;

public abstract class PlayerStateBase
{
    public virtual void EnterState(PlayerController player) { }
    //public virtual void Update(PlayerController player) { }
    public virtual void FixedUpdate(PlayerController player) { }
    public virtual void OnCollisionEnter(PlayerController player, Collision2D collision) { }
}
