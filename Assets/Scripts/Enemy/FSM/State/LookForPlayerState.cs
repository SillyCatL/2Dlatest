using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookForPlayerState : IState
{
    D_LookForPlayer d_LookForPlayer;

    protected float lastTurnTime;
    protected float amountTurn;
    protected bool isAllTurnDown;
    protected bool isAllTurnTimeDown;

    protected bool turnImmediately;
    public LookForPlayerState(BaseEntityEnemy baseEntityEnemy, BaseFSM baseFSM, D_LookForPlayer d_LookForPlayer) : base(baseEntityEnemy, baseFSM)
    {
        this.d_LookForPlayer = d_LookForPlayer;
    }

    public override void Enter()
    {
        base.Enter();

        isAllTurnDown = false;
        isAllTurnTimeDown = false;
        lastTurnTime = startTime;
        amountTurn = 0;

    }
    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        core.movement.SetVelocityZero();
        if (turnImmediately)
        {
            turnImmediately = false;
            baseEntityEnemy.Flip();
            amountTurn++;
            lastTurnTime = Time.time;
        }
        if ((Time.time >= lastTurnTime + d_LookForPlayer.turenBetweenTime) && !isAllTurnDown)
        {
            baseEntityEnemy.Flip();
            amountTurn++;
            lastTurnTime = Time.time;
        }
        if (amountTurn == d_LookForPlayer.truenCount)
        {
            isAllTurnDown = true;
        }
        if (isAllTurnDown && Time.time >= lastTurnTime + d_LookForPlayer.turenBetweenTime)
        {
            isAllTurnTimeDown = true;
        }
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public virtual void SetImmediatelyTurn()
    {
        turnImmediately = true;
    }
}
