using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class E2_Stun : SutnState
{
    E2_Entity e2_Entity;
    public E2_Stun(BaseEntityEnemy baseEntityEnemy, BaseFSM baseFSM, D_Stun d_Stun) : base(baseEntityEnemy, baseFSM, d_Stun)
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
        e2_Entity.ResetStun();
        e2_Entity.animator.SetBool("isStun",true);
    }
    public override void Exit()
    {
        base.Exit();
        e2_Entity.animator.SetBool("isStun",false);
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(isStunTimeOver)
        {
            if(isInCloseAttack)
            {
                baseFSM.ChangeState(StateId.meeleAttack);
            }
            else if(isPlayerInMaxAggroRange)
            {
                baseFSM.ChangeState(StateId.LongAttack);
            }
            else
            {
                baseFSM.ChangeState(StateId.lookForPlayer);
            }
        }
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();    
    }
}
