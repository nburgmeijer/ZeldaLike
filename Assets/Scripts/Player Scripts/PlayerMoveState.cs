using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : IPlayerState
{
    public void EnterState(PlayerController player)
    {
      
    }

    public void FixedUpdate(PlayerController player)
    {
        
        if (player.CanMove)
        {
            player.PlayerAnimator.SetBool("Walking", true);
            player.PlayerAnimator.SetFloat("MoveX", player.Change.x);    
            player.PlayerAnimator.SetFloat("MoveY", player.Change.y);
            Vector2 newPosition = player.transform.position + player.Change * player.MoveSpeed * Time.fixedDeltaTime;
            player.PlayerRigidBody.MovePosition(newPosition);
        }
        player.PlayerAnimator.SetBool("Walking", false);
        player.TransitionToState(player.IdleState);
    }

    public void OnCollisionEnter(PlayerController player, Collision2D collision)
    {
       
    }

    public void Update(PlayerController player)
    {
        
    }
}
