using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongAttack : AttackState
{
    D_LongAttack d_LongAttack;
    public LongAttack(BaseEntityEnemy baseEntityEnemy, BaseFSM baseFSM, Transform transform, D_LongAttack d_LongAttack) : base(baseEntityEnemy, baseFSM, transform)
    {
        this.d_LongAttack = d_LongAttack;
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

    public override void TriggerAttack()
    {
        GameObject arrow = GameObject.Instantiate(d_LongAttack.projectile, attackClosePos.position, attackClosePos.rotation);
        arrow.GetComponent<Projectile>().FireProjectile(d_LongAttack.projectileSpeed, d_LongAttack.projectileDis);
    }
}
