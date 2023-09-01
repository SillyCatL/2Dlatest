using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_Dead : DeadState
{
    E1_Entity e1_Entity;
    public E1_Dead(BaseEntityEnemy baseEntityEnemy, BaseFSM baseFSM, D_Dead d_Dead) : base(baseEntityEnemy, baseFSM, d_Dead)
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
