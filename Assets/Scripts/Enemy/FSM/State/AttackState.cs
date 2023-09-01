using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState
{

    protected bool isAnimationOver;
    protected bool isInCloseAttack;

    protected Transform attackClosePos;
    public AttackState(BaseEntityEnemy baseEntityEnemy, BaseFSM baseFSM,Transform transform) : base(baseEntityEnemy, baseFSM)
    {
        attackClosePos = transform;
    }
    
    protected override void GetCheckVal()
    {
        base.GetCheckVal();
        isInCloseAttack = baseEntityEnemy.CheckPlayerInCloseAttackRange();
    }
    public override void Enter()
    {
        base.Enter();
        baseEntityEnemy.animationInfer.attackState = this;
        isAnimationOver = false;
        
        core.movement.SetVelocityZero();
    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        core.movement.SetVelocityZero();
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();    
    }

    public virtual void TriggerAttack()
    {

    }

    public virtual void FinishAttack()
    {
        isAnimationOver = true;
    }
}
