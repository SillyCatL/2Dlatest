using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    protected D_IdleState d_IdleState;

    protected bool canFlip;

    protected bool isIdle;
    protected float idleTime;
    public IdleState(BaseEntityEnemy baseEntityEnemy, BaseFSM baseFSM, D_IdleState d_IdleState) : base(baseEntityEnemy, baseFSM)
    {
        this.d_IdleState = d_IdleState;
    }

    protected override void GetCheckVal()
    {
        base.GetCheckVal();
        
    }

    public override void Enter()
    {
        base.Enter();
        core.movement.SetVelocityX(0);
        SetRandomTime();
        isIdle = true;
    }

    public override void Exit()
    {
        base.Exit();

        if(canFlip)
          baseEntityEnemy.Flip();
    }


    public override void LogicUpdate()
    {
        base.LogicUpdate();
        core.movement.SetVelocityX(0);
        if(Time.time > startTime + idleTime)
        {
            isIdle = false;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    private void SetRandomTime()
    {
        idleTime = Random.Range(d_IdleState.minIdleTime, d_IdleState.maxIdleTime);
    }

    public void SetIfCanFlip(bool flip)
    {
        canFlip = flip;
    }
}
