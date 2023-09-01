using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SutnState : IState
{
    protected bool isStunTimeOver;
    protected D_Stun d_Stun;
    protected bool isGround;
    protected bool isInCloseAttack;
    public SutnState(BaseEntityEnemy baseEntityEnemy, BaseFSM baseFSM,D_Stun d_Stun) : base(baseEntityEnemy, baseFSM)
    {
        this.d_Stun = d_Stun;
    }
    protected override void GetCheckVal()
    {
        base.GetCheckVal();
        isInCloseAttack = baseEntityEnemy.CheckPlayerInCloseAttackRange();
        isGround = core.collisionSense.CheckTouchGround();
    }
    public override void Enter()
    {
        base.Enter();
        isStunTimeOver = false;
        core.movement.SetVelocity(d_Stun.stunSpeed,d_Stun.stunDir,baseEntityEnemy.attackFromRight);
    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(Time.time > startTime + d_Stun.stunTime)
            isStunTimeOver = true;
        if(isGround && Time.time > startTime + d_Stun.knockBackTime)
        {
            core.movement.SetVelocityX(0);
        }
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();    
    }

}
