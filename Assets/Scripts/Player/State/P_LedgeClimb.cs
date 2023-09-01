using System.Collections;
using System.Collections.Generic;
using Unity.Rendering.HybridV2;
using UnityEngine;

public class P_LedgeClimb : PlayerState
{
    protected Vector2 holdPos;
    protected Vector2 cornerPos;
    protected Vector2 climbPos;
    protected bool ClimbFinish;

    protected bool isHolding = false;
    protected bool isClimbing = false;
    protected int xInput;
    protected int yInput;
    protected bool jumpInput;
    public P_LedgeClimb(PlayerMachine playerMachine, Player player, PlayerData playerData) : base(playerMachine, player, playerData)
    {

    }
    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
        isHolding = true;
    }
    public override void AnimationFinish()
    {
        base.AnimationFinish();
        player.animator.SetBool("isClimb", false);
        ClimbFinish = true;
        isHolding = false;
    }
    public override void Enter()
    {
        base.Enter();
        ClimbFinish = false;
        isHolding = false;
        isClimbing = false;

        core.movement.SetVelocityZero();
        cornerPos = LedgeHoldPos();
        player.animator.SetBool("isHolding", true);

        holdPos.Set(cornerPos.x - (playerData.ledgeHoldOffset.x * core.movement.faceDirecion), cornerPos.y - playerData.ledgeHoldOffset.y);
        climbPos.Set(cornerPos.x + (playerData.ledgeFinishOffset.x * core.movement.faceDirecion), cornerPos.y + playerData.ledgeFinishOffset.y);

        player.transform.position = holdPos;
    }

    public override void Exit()
    {
        base.Exit();
        player.animator.SetBool("isHolding", false);

        if(isClimbing) //判断退出时候是否是因为climb产生的
        {
            player.transform.position = climbPos;
            isClimbing = false;
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        xInput = player.playerInput.inputX;
        yInput = player.playerInput.inputY;
        jumpInput = player.playerInput.Jump;

        core.movement.SetVelocityZero();
        player.transform.position = holdPos;

        if(ClimbFinish)
        {
            playerMachine.ChangeState(PlayerStateId.Idle);
        }
        else{
            if(yInput < 0 && isHolding && !isClimbing)
            {
                playerMachine.ChangeState(PlayerStateId.InAir);
            }
            else if(xInput != 0 && xInput == core.movement.faceDirecion && isHolding && !isClimbing)
            {
                player.animator.SetBool("isClimb", true);
                isClimbing = true;
            }
            else if(jumpInput && isHolding && !isClimbing)
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


    /// <summary>
    /// 找到攀爬点
    /// </summary>
    private Vector2 LedgeHoldPos()
    {
        Vector2 v2 = new Vector2();
        RaycastHit2D xHit = Physics2D.Raycast(core.collisionSense.wallTransform.position, player.transform.right, core.collisionSense.wallCheckDis, core.collisionSense.groundMask);
        v2.Set(xHit.distance * core.movement.faceDirecion, 0);
        RaycastHit2D yHit = Physics2D.Raycast(core.collisionSense.LedgeTranfromPlayer.position + (Vector3)v2, Vector2.down, core.collisionSense.ledgeCheckDis, core.collisionSense.groundMask);
        float a = yHit.distance;
        v2.Set(core.collisionSense.wallTransform.position.x + (xHit.distance * core.movement.faceDirecion), core.collisionSense.LedgeTranfromPlayer.position.y - a);
        return v2;
    }
}
