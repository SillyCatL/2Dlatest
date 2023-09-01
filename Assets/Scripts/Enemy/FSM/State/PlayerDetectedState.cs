using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectedState : IState
{
    protected D_PlayerDetected d_PlayerDetected;

    protected bool isInCloseAttack;
    protected bool isLedge;

    public PlayerDetectedState(BaseEntityEnemy baseEntityEnemy, BaseFSM baseFSM,D_PlayerDetected d_PlayerDetected) : base(baseEntityEnemy, baseFSM)
    {
        this.d_PlayerDetected = d_PlayerDetected;
    }

    protected override void GetCheckVal()
    {
        base.GetCheckVal();
        isInCloseAttack = baseEntityEnemy.CheckPlayerInCloseAttackRange();
        isLedge = core.collisionSense.CheckLedgeForEnemy();
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
        core.movement.SetVelocityZero();
        base.LogicUpdate();
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();    
    }
}
