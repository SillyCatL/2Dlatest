using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeState : IState
{
    D_Judge d_Judge;

    protected bool isDetecWall;
    protected bool isDetecLedge;
    protected bool isChargeTimeOver;
    protected bool isInCloseAttack;

    public JudgeState(BaseEntityEnemy baseEntityEnemy, BaseFSM baseFSM,D_Judge d_Judge) : base(baseEntityEnemy, baseFSM)
    {
        this.d_Judge = d_Judge;
    }

    protected override void GetCheckVal()
    {
        base.GetCheckVal();
        
        isPlayerInMinAggroRange = baseEntityEnemy.CheckPlayerInMinAggroRange();
        isDetecWall = core.collisionSense.CheckWall();
        isDetecLedge = core.collisionSense.CheckLedgeForEnemy();
        isInCloseAttack = baseEntityEnemy.CheckPlayerInCloseAttackRange();
    }

    public override void Enter()
    {
        base.Enter();
        
        isChargeTimeOver = false;
        core.movement.SetVelocityX(d_Judge.chaseSpeed * core.movement.faceDirecion);
    }
    public override void Exit()
    {
        base.Exit();
        core.movement.SetVelocityX(0);
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        core.movement.SetVelocityX(d_Judge.chaseSpeed * core.movement.faceDirecion);

        if(Time.time  > d_Judge.chaseTime + startTime)
        {
            isChargeTimeOver = true;
            
        }
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();    
    }

}
