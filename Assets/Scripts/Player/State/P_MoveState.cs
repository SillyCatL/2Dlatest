using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class P_MoveState : P_GroundState
{
    public P_MoveState(PlayerMachine playerMachine, Player player, PlayerData playerData) : base(playerMachine, player, playerData)
    {

    }

    public override void Enter()
    {
        base.Enter();
        player.animator.SetBool("isMove", true);
    }

    public override void Exit()
    {
        base.Exit();
        player.animator.SetBool("isMove", false);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        core.movement.CheckCanFlip(inputX);
        core.movement.SetVelocityX(inputX * playerData.moveVelocity);

        if (isInState)
        {
            if (inputX == 0)
            {
                playerMachine.ChangeState(PlayerStateId.Idle);
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
