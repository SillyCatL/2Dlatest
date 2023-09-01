using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_TouchWallState : PlayerState
{
    protected bool isTouchWall;
    protected bool isGround;
    protected bool isLedge;
    protected int xInput;
    protected int yInput;
    public P_TouchWallState(PlayerMachine playerMachine, Player player, PlayerData playerData) : base(playerMachine, player, playerData)
    {
    }
    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();


        xInput = player.playerInput.inputX;
        yInput = player.playerInput.inputY;

        if (isGround && player.playerInput.grab == false)
            playerMachine.ChangeState(PlayerStateId.Idle);
        if (!isTouchWall)
        {
            playerMachine.ChangeState(PlayerStateId.InAir);
        }
        else if(isTouchWall && !isLedge)
        {
            playerMachine.ChangeState(PlayerStateId.Ledge);
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void GetCheckVal()
    {
        base.GetCheckVal();
        isTouchWall = core.collisionSense.CheckWall();
        isGround = core.collisionSense.CheckTouchGround();
        isLedge = core.collisionSense.CheckLedgeForPlayer();
    }
}
