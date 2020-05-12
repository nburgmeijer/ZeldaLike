using UnityEngine;

public class PlayerMoveState : PlayerStateBase
{
    public override void EnterState(PlayerController player)
    {
        player.PlayerAnimator.SetBool("Walking", true);
    }

    public override void FixedUpdate(PlayerController player)
    {
        if (player.CanMove)
        {
            player.PlayerAnimator.SetFloat("MoveX", player.Change.x);    
            player.PlayerAnimator.SetFloat("MoveY", player.Change.y);
            Vector2 newPosition = player.transform.position + player.Change * player.MoveSpeed * Time.fixedDeltaTime;
            player.PlayerRigidBody.MovePosition(newPosition);
        }
    }
}
