using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IState
{
    public float startTime { get; protected set; }

    protected Core core;

    protected bool isPlayerInMinAggroRange;
    protected bool isPlayerInMaxAggroRange;

    protected BaseEntityEnemy baseEntityEnemy;
    protected BaseFSM baseFSM;

    public IState(BaseEntityEnemy baseEntityEnemy, BaseFSM baseFSM)
    {
        this.baseEntityEnemy = baseEntityEnemy;
        this.baseFSM = baseFSM;
    }

    protected virtual void GetCheckVal()
    {
        isPlayerInMaxAggroRange = baseEntityEnemy.CheckPlayerInMaxAggroRange();
        isPlayerInMinAggroRange = baseEntityEnemy.CheckPlayerInMinAggroRange();
    }

    public virtual void Enter()
    {
        core = baseEntityEnemy.core;
        startTime = Time.time;
        GetCheckVal();
    }

    public virtual void Exit()
    {

    }

    public virtual void LogicUpdate()
    {
        GetCheckVal();
    }

    public virtual void PhysicsUpdate()
    {

    }
}
