using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_StunState : SutnState
{
    E1_Entity e1_Entity;
    public E1_StunState(BaseEntityEnemy baseEntityEnemy, BaseFSM baseFSM, D_Stun d_Stun) : base(baseEntityEnemy, baseFSM, d_Stun)
    {
        e1_Entity = baseEntityEnemy as E1_Entity;
    }
    protected override void GetCheckVal()
    {
        base.GetCheckVal();
    }
    public override void Enter()
    {
        base.Enter();
        e1_Entity.animator.SetBool("isStun",true);
    }
    public override void Exit()
    {
        base.Exit();
        e1_Entity.ResetStun();
        e1_Entity.animator.SetBool("isStun",false);
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
            else if(isPlayerInMinAggroRange)
            {
                baseFSM.ChangeState(StateId.judge);
            }
            else
            {
                e1_Entity.e1_LooForPlayer.SetImmediatelyTurn();
                baseFSM.ChangeState(StateId.lookForPlayer);
            }
        }
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();    
    }
}
