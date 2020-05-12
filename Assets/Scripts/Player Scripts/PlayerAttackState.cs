using System.Collections;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

public class PlayerAttackState : PlayerStateBase
{
 
    public override void EnterState(PlayerController player)
    {
        player.PlayerControls.PlayerControlsActionMap.Attack.Disable();
        player.StartCoroutine(AttackCo(player));
       
        
            
        
    }

    public override void OnCollisionEnter(PlayerController player, Collision2D collision)
    {
        Debug.Log(collision);
    }

    private IEnumerator AttackCo(PlayerController player)
    {
        player.PlayerAnimator.SetBool("Attacking", true);
        yield return null;
        ContactFilter2D contactFilter2D = new ContactFilter2D() { minDepth = 1, maxDepth = 3, useDepth = true };
        Collider2D[] hits = new Collider2D[3];
        int totalHits = (player.SwordDownCollider.OverlapCollider(contactFilter2D, hits));
        for (int i = 0; i < totalHits; i++)
        {
            Debug.Log(hits[i]);
        }
        player.TransitionToState(player.LastState);
        yield return new WaitForSeconds(0.14f);
       
        /* 

         int totalHits = Physics2D.OverlapCollider(player.SwordDownCollider, contactFilter2D, hits);
         for (int i = 0; i < totalHits; i++)
         {
             Debug.Log(hits[i]);
         }*/
        player.PlayerAnimator.SetBool("Attacking", false);
        yield return new WaitForSeconds(0.2f);
        player.PlayerControls.PlayerControlsActionMap.Attack.Enable();
    }
}
