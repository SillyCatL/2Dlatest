using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_GroundState : PlayerState
{
    protected int inputX;
    protected bool inputJump;
    protected bool dashInput;
    protected bool isGround;
    protected bool isLedge; //防止人物在过低的平台实现grab操作，从而错误的进入ledgeClimb操作
    protected bool isTouchWall;
    protected Vector2 velocity;
    public P_GroundState(PlayerMachine playerMachine, Player player, PlayerData playerData) : base(playerMachine, player, playerData)
    {
    }    
    
    public override void Enter()
    {
        base.Enter();

        player.p_DashState.ResetDash();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        inputX = player.playerInput.inputX;
        inputJump = player.playerInput.Jump;
        dashInput = player.playerInput.dashInput;

        if (inputJump)
        {
            player.playerInput.UseJump();
            playerMachine.ChangeState(PlayerStateId.Jump);
        }
        else if(player.playerInput.attackArray[(int)PlayerInput.attackInput.primaryAttack])
        {
            playerMachine.ChangeState(PlayerStateId.Attack);
        }
        else if(player.playerInput.attackArray[(int)PlayerInput.attackInput.secondAttack])
        {
            playerMachine.ChangeState(PlayerStateId.Attack);
        }
        else if (isGround && player.playerInput.grab && isTouchWall && isLedge)
        {
            playerMachine.ChangeState(PlayerStateId.WallGrab);
        }
        else if(dashInput && player.p_DashState.CheckCanDash())
        {
            player.p_DashState.GetAnimation(playerMachine.StateId);
            playerMachine.ChangeState(PlayerStateId.Dash);
        }
        if(isGround == false)
        {
            player.p_InAirState.StartCoyotTime();
            playerMachine.ChangeState(PlayerStateId.InAir);
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
        core.collisionSense.CheckWall();
        isLedge = core.collisionSense.CheckLedgeForPlayer();
    }
}
