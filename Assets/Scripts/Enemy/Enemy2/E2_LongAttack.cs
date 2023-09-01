using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_LongAttack : LongAttack
{
    E2_Entity e2_Entity;
    public E2_LongAttack(BaseEntityEnemy baseEntityEnemy, BaseFSM baseFSM, Transform transform, D_LongAttack d_LongAttack) : base(baseEntityEnemy, baseFSM, transform, d_LongAttack)
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
        e2_Entity.animator.SetBool("isLongAttack",true);
        
    }
    public override void Exit()
    {
        base.Exit();
        e2_Entity.animator.SetBool("isLongAttack",false);
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(isAnimationOver)
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
