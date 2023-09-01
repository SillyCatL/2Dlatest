using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_LooForPlayer : LookForPlayerState
{
    E1_Entity e1_Entity;
    public E1_LooForPlayer(BaseEntityEnemy baseEntityEnemy, BaseFSM baseFSM, D_LookForPlayer d_LookForPlayer) : base(baseEntityEnemy, baseFSM, d_LookForPlayer)
    {
        this.e1_Entity = baseEntityEnemy as E1_Entity;
    }   
    public override void Enter()
    {
        base.Enter();
        e1_Entity.animator.SetBool("isLookFor",true);

    }
    public override void Exit()
    {
        base.Exit();
        e1_Entity.animator.SetBool("isLookFor",false);
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(isPlayerInMinAggroRange)
        {
            baseFSM.ChangeState(StateId.playerDetected);
        }
        if(isAllTurnTimeDown)
        {
            baseFSM.ChangeState(StateId.walk);
        }
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();    
    }
}
