using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class P_InAirState : PlayerState
{
    #region  Input
    protected bool inputDash;
    protected int inputX;
    #endregion 

    #region  Check
    protected bool isGround;
    protected bool isJumpingUp;
    protected bool isLedge;
    protected bool isTouchWall;
    #endregion

    protected bool ifCoyoteTime = false; //滞空
    public P_InAirState(PlayerMachine playerMachine, Player player, PlayerData playerData) : base(playerMachine, player, playerData)
    {

    }
    public override void Enter()
    {
        base.Enter();
        player.animator.SetBool("isInAir", true);
    }

    public override void Exit()
    {
        base.Exit();
        player.animator.SetBool("isInAir", false);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        CheckIFCoyotTime();
        CheckJumpDetail();

        inputX = player.playerInput.inputX;
        inputDash = player.playerInput.dashInput;

        if (ifCoyoteTime && player.playerInput.Jump)
        {
            player.playerInput.UseJump();
            playerMachine.ChangeState(PlayerStateId.Jump);
        }

        if (isGround && player.rb.velocity.y < 0.1f)
        {
            playerMachine.ChangeState(PlayerStateId.Land);
        }
        else if (player.playerInput.attackArray[(int)PlayerInput.attackInput.primaryAttack])
        {
            playerMachine.ChangeState(PlayerStateId.Attack);
        }
        else if (player.playerInput.attackArray[(int)PlayerInput.attackInput.secondAttack])
        {
            playerMachine.ChangeState(PlayerStateId.Attack);
        }
        else if (inputDash && player.p_DashState.CheckCanDash())
        {
            playerMachine.ChangeState(PlayerStateId.Dash);
        }
        else if (isTouchWall && !isLedge && !isGround)
        {
            playerMachine.ChangeState(PlayerStateId.Ledge);
        }
        else if (isTouchWall && player.playerInput.grab == true && isLedge)
        {
            playerMachine.ChangeState(PlayerStateId.WallGrab);
        }
        else if (isTouchWall && inputX == core.movement.faceDirecion && player.rb.velocity.y < 0)
        {
            playerMachine.ChangeState(PlayerStateId.WallSlide);
        }
        else //移动
        {
            core.movement.CheckCanFlip(inputX);
            core.movement.SetVelocityX(inputX * playerData.moveVelocity);

            player.animator.SetFloat("yVelocity", player.rb.velocity.y);
            player.animator.SetFloat("xVelocity", MathF.Abs(player.rb.velocity.x));
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
        isTouchWall = core.collisionSense.CheckWall();
        isLedge = core.collisionSense.CheckLedgeForPlayer();
    }

    public void StartCoyotTime()
    {
        ifCoyoteTime = true;
    }
    public void StartJumpUp()
    {
        isJumpingUp = true;
    }
    private void CheckIFCoyotTime()
    {
        if (Time.time > startTime + playerData.coyoteTime)
            ifCoyoteTime = false;
    }

    private void CheckJumpDetail()
    {
        if (isJumpingUp)
        {
            if (player.rb.velocity.y < 0)
            {
                isJumpingUp = false;
            }
            if (player.playerInput.JumpStop == true)
            {
                isJumpingUp = false;
                core.movement.SetVelocityY(player.rb.velocity.y * playerData.jumpBanForce);
            }
        }
    }
}
