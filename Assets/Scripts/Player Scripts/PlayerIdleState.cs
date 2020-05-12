using System.Collections;
using UnityEngine;

public class PlayerIdleState : PlayerStateBase
{

    public override void EnterState(PlayerController player)
    {
        if(player.PlayerAnimator.GetBool("Walking") == true)
        {
            player.PlayerAnimator.SetBool("Walking", false);
        }
        
    }
}
