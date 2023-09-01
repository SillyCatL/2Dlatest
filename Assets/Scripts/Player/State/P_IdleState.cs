using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_IdleState : P_GroundState
{
    public P_IdleState(PlayerMachine playerMachine, Player player, PlayerData playerData) : base(playerMachine, player, playerData)
    {

    }
    public override void Enter()
    {
        base.Enter();
        core.movement.SetVelocityX(0);
        player.animator.SetBool("isIdle", true);
    }

    public override void Exit()
    {
        base.Exit();
        player.animator.SetBool("isIdle", false);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (inputX != 0 && isInState)
        {
            playerMachine.ChangeState(PlayerStateId.Move);
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
