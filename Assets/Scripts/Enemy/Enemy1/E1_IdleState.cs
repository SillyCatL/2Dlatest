using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_IdleState : IdleState
{
    protected E1_Entity e1_Entity;
    public E1_IdleState(BaseEntityEnemy baseEntityEnemy, BaseFSM baseFSM, D_IdleState d_IdleState) : base(baseEntityEnemy, baseFSM, d_IdleState)
    {
        e1_Entity = baseEntityEnemy as E1_Entity;
    }

    public override void Enter()
    {
        base.Enter();
        e1_Entity.animator.SetBool("isIdle",true);

    }
    public override void Exit()
    {
        base.Exit();
        e1_Entity.animator.SetBool("isIdle",false);
    }


    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(isIdle == false) ///检测转换到walk状态
        {
            baseFSM.ChangeState(StateId.walk);
        }
        else  if(isPlayerInMinAggroRange) ///转换到playerDetected状态
        {
            baseFSM.ChangeState(StateId.playerDetected);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
