using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_PlayerDetected : PlayerDetectedState
{
    E2_Entity e2_Entity;
    public E2_PlayerDetected(BaseEntityEnemy baseEntityEnemy, BaseFSM baseFSM, D_PlayerDetected d_PlayerDetected) : base(baseEntityEnemy, baseFSM, d_PlayerDetected)
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
        e2_Entity.animator.SetBool("isPlayerDetected",true);
    }
    public override void Exit()
    {
        base.Exit();
        e2_Entity.animator.SetBool("isPlayerDetected",false);
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(isInCloseAttack)
        {
            if(Time.time > e2_Entity.e2_Dodge.startTime + e2_Entity.d_Dodge.dodgeCoolTime)
            {
                baseFSM.ChangeState(StateId.Dodge);
            }
            else 
            {
                baseFSM.ChangeState(StateId.meeleAttack);
            }
        }

        if(Time.time > startTime + d_PlayerDetected.detectedTime)
        {
            baseFSM.ChangeState(StateId.LongAttack);
        }

        if(!isPlayerInMaxAggroRange)
        {
            baseFSM.ChangeState(StateId.lookForPlayer);
        }
        if(!isLedge)
        {
            e2_Entity.Flip();
            baseFSM.ChangeState(StateId.walk);
        }
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();    
    }
}
