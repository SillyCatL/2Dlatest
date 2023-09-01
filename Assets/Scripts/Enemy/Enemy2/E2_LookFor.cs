using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_LookFor : LookForPlayerState
{
    E2_Entity e2_Entity;
    public E2_LookFor(BaseEntityEnemy baseEntityEnemy, BaseFSM baseFSM, D_LookForPlayer d_LookForPlayer) : base(baseEntityEnemy, baseFSM, d_LookForPlayer)
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
        e2_Entity.animator.SetBool("isLookFor",true);
        
    }
    public override void Exit()
    {
        base.Exit();
        e2_Entity.animator.SetBool("isLookFor",false);
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(isPlayerInMinAggroRange)
        {
            baseFSM.ChangeState(StateId.playerDetected);
        }
        else if(isAllTurnTimeDown)
        {
            baseFSM.ChangeState(StateId.walk);
        }
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();    
    }
}
