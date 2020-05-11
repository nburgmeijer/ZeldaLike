using UnityEngine;

public class PlayerIdleState : IPlayerState
{

    public void EnterState(PlayerController player)
    {
        if(player.PlayerAnimator.GetBool("Walking") == true)
        {
            player.PlayerAnimator.SetBool("Walking", false);
        }
        
    }

    public void FixedUpdate(PlayerController player)
    {
        
    }

    public void OnCollisionEnter(PlayerController player, Collision2D collision)
    {
        
    }

    public void Update(PlayerController player)
    {
      
    }
}
