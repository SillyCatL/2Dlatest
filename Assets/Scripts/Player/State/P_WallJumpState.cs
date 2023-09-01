using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class P_WallJumpState : P_AbilityState
{
    protected bool dashInput;
    protected int jumpDir = 1;
    public P_WallJumpState(PlayerMachine playerMachine, Player player, PlayerData playerData) : base(playerMachine, player, playerData)
    {

    }    
    public override void Enter()
    {
        base.Enter();
        player.animator.SetBool("isInAir", true);

        player.playerInput.UseJump();
        player.p_InAirState.StartJumpUp();
        core.movement.SetVelocity(playerData.wallJumpForce, playerData.wallJumpAngle,jumpDir);
        core.movement.CheckCanFlip(jumpDir);
    }

    public override void Exit()
    {
        base.Exit();
        player.animator.SetBool("isInAir", false);
    }

    public override void LogicUpdate()  
    {
        base.LogicUpdate();

        dashInput = player.playerInput.dashInput;
        player.animator.SetFloat("yVelocity", player.rb.velocity.y);
        player.animator.SetFloat("xVelocity", System.MathF.Abs(player.rb.velocity.x));


        if (Time.time > startTime + playerData.wallJumpTime || player.playerInput.JumpStop == true) //撤离登墙跳的时间   
        {
            isAbilityOver = true;
        }
        else if (dashInput && player.p_DashState.CheckCanDash())
        {
            isAbilityOver = true;
            playerMachine.ChangeState(PlayerStateId.Dash);
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

    public void DecideJumpDir(int faceDir)
    {
        jumpDir = faceDir;
    }
}
