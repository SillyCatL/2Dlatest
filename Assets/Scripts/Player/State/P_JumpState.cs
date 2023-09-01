using System.Collections;
using System.Collections.Generic;
using UnityEngine;using System;

public class P_JumpState : P_AbilityState
{
    public P_JumpState(PlayerMachine playerMachine, Player player, PlayerData playerData) : base(playerMachine, player, playerData)
    {
    }
    public override void Enter()
    {
        base.Enter();
        core.movement.SetVelocityY(playerData.JumpForce);
        player.animator.SetBool("isInAir", true);
        isAbilityOver = true;
        player.p_InAirState.StartJumpUp();
    }

    public override void Exit()
    {
        base.Exit();
        player.animator.SetBool("isInAir", false);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
        player.animator.SetFloat("yVelocity", player.rb.velocity.y);
        player.animator.SetFloat("xVelocity", MathF.Abs(player.rb.velocity.x));
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
