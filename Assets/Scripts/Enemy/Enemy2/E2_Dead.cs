using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_Dead : DeadState
{
    E2_Entity   e2_Entity;
    public E2_Dead(BaseEntityEnemy baseEntityEnemy, BaseFSM baseFSM, D_Dead d_Dead) : base(baseEntityEnemy, baseFSM, d_Dead)
    {
        this.e2_Entity = baseEntityEnemy as E2_Entity;
    }    
    
    protected override void GetCheckVal()
    {
        base.GetCheckVal();
    }
    public override void Enter()
    {
        base.Enter();
        
    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();    
    }
}
