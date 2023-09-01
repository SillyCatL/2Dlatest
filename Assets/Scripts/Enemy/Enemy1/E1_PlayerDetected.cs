using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_PlayerDetected : PlayerDetectedState
{
    E1_Entity e1_Entity;
    public E1_PlayerDetected(BaseEntityEnemy baseEntityEnemy, BaseFSM baseFSM, D_PlayerDetected d_PlayerDetected) : base(baseEntityEnemy, baseFSM, d_PlayerDetected)
    {
        e1_Entity = baseEntityEnemy as E1_Entity;
    }

    public override void Enter()
    {
        base.Enter();
        e1_Entity.animator.SetBool("isPlayerDetected", true);
    }
    public override void Exit()
    {
        base.Exit();
        e1_Entity.animator.SetBool("isPlayerDetected", false);
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(isInCloseAttack)
        {
            baseFSM.ChangeState(StateId.meeleAttack);
        }

        ///转换到loofor状态
        if(!isPlayerInMaxAggroRange)
        {
            baseFSM.ChangeState(StateId.lookForPlayer);
        }

        ///转换judge状态
        if(Time.time > startTime + d_PlayerDetected.detectedTime)
        {
            baseFSM.ChangeState(StateId.judge);
        }

        if(!isLedge)
        {
            e1_Entity.Flip();
            baseFSM.ChangeState(StateId.walk);
        }

    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
