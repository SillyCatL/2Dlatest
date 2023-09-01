using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_Dodge : Dodge
{
    E2_Entity e2_Entity;
    public E2_Dodge(BaseEntityEnemy baseEntityEnemy, BaseFSM baseFSM, D_Dodge d_Dodge) : base(baseEntityEnemy, baseFSM, d_Dodge)
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
        e2_Entity.animator.SetBool("isDodge",true);
        

    }
    public override void Exit()
    {
        base.Exit();
        e2_Entity.animator.SetBool("isDodge",false);
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isDodgeOver)
        {
            if (isInMaxRange)
            {
                if (isInCloseAttack)
                {
                    baseFSM.ChangeState(StateId.meeleAttack);
                }
                else
                {
                    baseFSM.ChangeState(StateId.LongAttack);
                }
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
