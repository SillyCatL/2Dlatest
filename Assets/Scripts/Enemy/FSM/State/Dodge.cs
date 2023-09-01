using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Dodge : IState
{
    D_Dodge d_Dodge;
    protected bool isInCloseAttack;
    protected bool isInMaxRange;
    protected bool isGround;
    protected bool isDodgeOver;
    public Dodge(BaseEntityEnemy baseEntityEnemy, BaseFSM baseFSM, D_Dodge d_Dodge) : base(baseEntityEnemy, baseFSM)
    {
        this.d_Dodge = d_Dodge;
    }
    protected override void GetCheckVal()
    {
        base.GetCheckVal();
        baseEntityEnemy.animator.SetFloat("yVelocity", baseEntityEnemy.core.movement.rb.velocity.y);
        isInCloseAttack = baseEntityEnemy.CheckPlayerInCloseAttackRange();
        isInMaxRange = isPlayerInMaxAggroRange;
        isGround = core.collisionSense.CheckTouchGround();
    }
    public override void Enter()
    {
        base.Enter();
        core.movement.SetVelocity(d_Dodge.dodgeSpeed, d_Dodge.dodgeAngle, -baseEntityEnemy.core.movement.faceDirecion);
        isDodgeOver = false;
    }
        
    public override void Exit()
    {
        base.Exit();
        core.movement.SetVelocityX(0);
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (Time.time > startTime + d_Dodge.dodgeTime || (Time.time > startTime + 0.2f && isGround)) //直接isGround会在开始跳时候结束，产生错误
        {
            isDodgeOver = true;
        }
        
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
