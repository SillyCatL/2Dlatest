using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : IState
{
    D_Dead d_Dead;
    public DeadState(BaseEntityEnemy baseEntityEnemy, BaseFSM baseFSM, D_Dead d_Dead) : base(baseEntityEnemy, baseFSM)
    {
        this.d_Dead = d_Dead;
    }

    protected override void GetCheckVal()
    {
        base.GetCheckVal();
    }
    public override void Enter()
    {
        base.Enter();

        GameObject.Instantiate(d_Dead.deathBlood, baseEntityEnemy.transform).transform.parent = baseEntityEnemy.transform;
        GameObject.Instantiate(d_Dead.deathChunk, baseEntityEnemy.transform).transform.parent = baseEntityEnemy.transform;
        baseEntityEnemy.gameObject.transform.Find("Alive").gameObject.SetActive(false);
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
