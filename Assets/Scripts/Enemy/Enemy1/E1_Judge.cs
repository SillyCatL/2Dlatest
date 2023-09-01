using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_Judge : JudgeState
{
    E1_Entity e1_Entity;
    public E1_Judge(BaseEntityEnemy baseEntityEnemy, BaseFSM baseFSM, D_Judge d_Judge) : base(baseEntityEnemy, baseFSM, d_Judge)
    {
        e1_Entity = baseEntityEnemy as E1_Entity;
    }
    public override void Enter()
    {
        base.Enter();
        e1_Entity.animator.SetBool("isJudge", true);
    }
    public override void Exit()
    {
        base.Exit();
        e1_Entity.animator.SetBool("isJudge", false);
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(isInCloseAttack)
        {
            baseFSM.ChangeState(StateId.meeleAttack);
        }

        if(isDetecWall || !isDetecLedge)
        {
            baseFSM.ChangeState(StateId.lookForPlayer);
        }

        if(isChargeTimeOver)
        {
            if(isPlayerInMinAggroRange)
            {
                baseFSM.ChangeState(StateId.playerDetected);
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
