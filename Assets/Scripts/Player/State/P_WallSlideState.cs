using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_WallSlideState : P_TouchWallState
{
    public P_WallSlideState(PlayerMachine playerMachine, Player player, PlayerData playerData) : base(playerMachine, player, playerData)
    {
    }
    public override void Enter()
    {
        base.Enter();
        player.animator.SetBool("isWallSliding", true);
    }

    public override void Exit()
    {
        base.Exit();
        player.animator.SetBool("isWallSliding", false);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        core.movement.SetVelocityY(playerData.slideVelocity);

        if (isInState)
        {
            if (player.playerInput.grab && yInput == 0)
            {
                playerMachine.ChangeState(PlayerStateId.WallGrab);
            }
            else if (isTouchWall && player.playerInput.Jump)
            {
                player.P_WallJumpState.DecideJumpDir(-core.movement.faceDirecion);
                playerMachine.ChangeState(PlayerStateId.WallJump);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void GetCheckVal()
    {
        base.GetCheckVal();
    }
}
