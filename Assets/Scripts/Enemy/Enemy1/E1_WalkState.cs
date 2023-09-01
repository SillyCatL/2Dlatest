using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class E1_WalkState : WalkState
{
    E1_Entity e1_Entity;
    public E1_WalkState(BaseEntityEnemy baseEntityEnemy, BaseFSM baseFSM, D_WalkState d_WalkState) : base(baseEntityEnemy, baseFSM, d_WalkState)
    {
        e1_Entity = baseEntityEnemy as E1_Entity;
    }

    public override void Enter()
    {
        base.Enter();
        e1_Entity.animator.SetBool("isWalk",true);

    }
    public override void Exit()
    {
        base.Exit();
        e1_Entity.animator.SetBool("isWalk",false);
    }


    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
        ///检测Idle状态
        if(isDetecWall || !isDetecLedge)
        {
            e1_Entity.e1_IdleState.SetIfCanFlip(true);
            baseFSM.ChangeState(StateId.idle);
        }
        else if(isPlayerInMinAggroRange) ///检测转换到playerDetected状态
        {
            e1_Entity.core.movement.SetVelocityX(0);
            baseFSM.ChangeState(StateId.playerDetected);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
