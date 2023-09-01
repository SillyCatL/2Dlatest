using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_WallGrabState : P_TouchWallState
{
    private Vector3 pos;
    public P_WallGrabState(PlayerMachine playerMachine, Player player, PlayerData playerData) : base(playerMachine, player, playerData)
    {
    }
    public override void Enter()
    {
        base.Enter();
        player.animator.SetBool("isWallGrab", true);

        pos = player.transform.position;
    }

    public override void Exit()
    {
        base.Exit();
        player.animator.SetBool("isWallGrab", false);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        HoldPos();

        if (isInState)
        {
            if (player.playerInput.grab == false || yInput < 0)
            {
                playerMachine.ChangeState(PlayerStateId.WallSlide);
            }
            else if (yInput > 0)
            {
                playerMachine.ChangeState(PlayerStateId.WallClimb);
            }
            else if (isTouchWall && player.playerInput.Jump)
            {
                player.P_WallJumpState.DecideJumpDir(-core.movement.faceDirecion);
                playerMachine.ChangeState(PlayerStateId.WallJump);
            }
        }
    }

    private void HoldPos() ///保证grab时期人物不会进行移动，将position固定，否则的话下降，(重力影响比update频率高?)
    {
        player.transform.position = pos;

        core.movement.SetVelocityX(0);
        core.movement.SetVelocityY(0);
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
