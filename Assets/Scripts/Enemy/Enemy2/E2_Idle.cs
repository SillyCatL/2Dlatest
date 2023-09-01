using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_Idle : IdleState
{
    E2_Entity e2_Entity;

    public E2_Idle(BaseEntityEnemy baseEntityEnemy, BaseFSM baseFSM, D_IdleState d_IdleState) : base(baseEntityEnemy, baseFSM, d_IdleState)
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
        e2_Entity.animator.SetBool("isIdle",true);        
    }
    public override void Exit()
    {
        base.Exit();
        e2_Entity.animator.SetBool("isIdle",false);
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(isIdle == false)
        {
            baseFSM.ChangeState(StateId.walk);
        }
        else if(isPlayerInMinAggroRange)
        {
            baseFSM.ChangeState(StateId.playerDetected);
        }
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();    
    }
}
