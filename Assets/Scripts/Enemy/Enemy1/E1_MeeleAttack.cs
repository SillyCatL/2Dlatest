using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_MeeleAttack : MeeleAttackState
{
    E1_Entity e1_Entity;
    public E1_MeeleAttack(BaseEntityEnemy baseEntityEnemy, BaseFSM baseFSM, Transform transform, D_MeeleAttack d_MeeleAttack) : base(baseEntityEnemy, baseFSM, transform, d_MeeleAttack)
    {
        this.e1_Entity = baseEntityEnemy as E1_Entity;
    }

    public override void Enter()
    {
        base.Enter();
        isAnimationOver = false;
        e1_Entity.animator.SetBool("isAttack", true);
    }
    public override void Exit()
    {
        base.Exit();
        e1_Entity.animator.SetBool("isAttack", false);
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
