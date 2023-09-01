using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_Walk : WalkState
{
    E2_Entity e2_Entity;
    public E2_Walk(BaseEntityEnemy baseEntityEnemy, BaseFSM baseFSM, D_WalkState d_WalkState) : base(baseEntityEnemy, baseFSM, d_WalkState)
    {
        e2_Entity = baseEntityEnemy as E2_Entity;
    }
    protected override void GetCheckVal()
    {
        base.GetCheckVal();
    }
    public override void Enter()
    {
        base.Enter();
            e2_Entity.animator.SetBool("isWalk",true);
        
    }
    public override void Exit()
    {
        base.Exit();
        e2_Entity.animator.SetBool("isWalk",false);
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(!isDetecLedge || isDetecWall)
        {
            e2_Entity.e2_Idle.SetIfCanFlip(true);
            baseFSM.ChangeState(StateId.idle);
        }
        else if(isPlayerInMinAggroRange)
        {
            e2_Entity.core.movement.SetVelocityX(0);
            baseFSM.ChangeState(StateId.playerDetected);
        }
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();    
    }
}
