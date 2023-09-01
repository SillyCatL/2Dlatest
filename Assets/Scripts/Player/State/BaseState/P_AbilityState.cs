using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_AbilityState : PlayerState
{
    protected bool isGround;
    protected bool isAbilityOver;
    public P_AbilityState(PlayerMachine playerMachine, Player player, PlayerData playerData) : base(playerMachine, player, playerData)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        isAbilityOver = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(isAbilityOver)
        {
            if(isGround && player.rb.velocity.y < 0.1f)
            {
                playerMachine.ChangeState(PlayerStateId.Idle);
            }
            else
            {
                playerMachine.ChangeState(PlayerStateId.InAir);
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
        isGround = core.collisionSense.CheckTouchGround();
    }
}
