using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_WallClimb : P_TouchWallState
{
    public P_WallClimb(PlayerMachine playerMachine, Player player, PlayerData playerData) : base(playerMachine, player, playerData)
    {
    }
    public override void Enter()
    {
        base.Enter();
        player.animator.SetBool("isWallClimb", true);
    }

    public override void Exit()
    {
        base.Exit();
        player.animator.SetBool("isWallClimb", false);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        core.movement.SetVelocityY(playerData.wallClimbVelocity);

        if (isInState)
        {
            if (yInput != 1)//
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
