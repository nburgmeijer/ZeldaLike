using System.Collections;
using UnityEngine;

public class PlayerAttackState : PlayerStateBase
{
 
    public override void EnterState(PlayerController player)
    {
        player.PlayerControls.PlayerControlsActionMap.Attack.Disable();
        player.StartCoroutine(AttackCo(player));  
    }
    public override void OnTriggerEnter(PlayerController player, Collider2D collision)
    {
        Debug.Log(collision.tag);
    }


    private IEnumerator AttackCo(PlayerController player)
    {
        player.PlayerAnimator.SetBool("Attacking", true);
        yield return null;
        player.TransitionToState(player.LastState);
        yield return new WaitForSeconds(0.14f);
        player.PlayerAnimator.SetBool("Attacking", false);
        yield return new WaitForSeconds(0.2f);
        player.PlayerControls.PlayerControlsActionMap.Attack.Enable();
    }
}
