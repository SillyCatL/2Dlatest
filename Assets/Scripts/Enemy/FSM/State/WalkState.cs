using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : IState
{   
    protected D_WalkState d_WalkState;

    protected bool isDetecWall;
    protected bool isDetecLedge;
    public WalkState(BaseEntityEnemy baseEntityEnemy, BaseFSM baseFSM , D_WalkState d_WalkState) : base(baseEntityEnemy, baseFSM)
    {
        this.d_WalkState = d_WalkState;
    }

    protected override void GetCheckVal()
    {
        base.GetCheckVal();
        
        isDetecWall = core.collisionSense.CheckWall();
        isDetecLedge = core.collisionSense.CheckLedgeForEnemy();
    }

    public override void Enter()
    {
        base.Enter();
        core.movement.SetVelocityX(d_WalkState.walkSpeed * core.movement.faceDirecion);
    }

    public override void Exit()
    {
        base.Exit();
    }


    public override void LogicUpdate()
    {
        base.LogicUpdate();
        core.movement.SetVelocityX(d_WalkState.walkSpeed * core.movement.faceDirecion);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

