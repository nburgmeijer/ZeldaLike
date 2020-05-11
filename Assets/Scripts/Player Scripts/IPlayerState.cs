using UnityEngine;

public interface IPlayerState
{
    void EnterState(PlayerController player);
    void Update(PlayerController player);
    void FixedUpdate(PlayerController player);
    void OnCollisionEnter(PlayerController player, Collision2D collision);

}
