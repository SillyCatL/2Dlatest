using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleAttackState : AttackState
{
    D_MeeleAttack d_MeeleAttack;

    public MeeleAttackState(BaseEntityEnemy baseEntityEnemy, BaseFSM baseFSM, Transform transform, D_MeeleAttack d_MeeleAttack) : base(baseEntityEnemy, baseFSM, transform)
    {
        this.d_MeeleAttack = d_MeeleAttack;
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
        base.TriggerAttack();

        Collider2D[] attackDetected = Physics2D.OverlapCircleAll(attackClosePos.position, d_MeeleAttack.attackRadius, d_MeeleAttack.player);

        foreach (Collider2D collider in attackDetected)
        {

            IDamageable damageable = collider.GetComponentInChildren<IDamageable>();
            if (damageable != null)
            {
                damageable.KnockBack(d_MeeleAttack.knockAngle, d_MeeleAttack.knockStrength, core.movement.faceDirecion);
                damageable.Damage(d_MeeleAttack.attackDamage);
            }
        }
    }
}
