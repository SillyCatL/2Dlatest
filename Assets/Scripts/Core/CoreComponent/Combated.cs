using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combated : CoreComponent, IDamageable
{
    private bool isInKnock;

    [SerializeField]
    private GameObject damageParticle;
    protected override void Update()
    {
        base.Update();
        CheckCanMove();
    }
    public void Damage(float damage)
    {
        core.stats.DecreseHealth(damage);
        core.particle.StartParticlesWithRandowmRotation(damageParticle, core.movement.rb.transform.position);    
    }

    public void KnockBack(Vector2 angle, float strength, int direction)
    {
        core.movement.SetVelocity(strength, angle, direction);
        isInKnock = true;
        core.movement.canMove = false;
    }

    private void CheckCanMove()
    {
        if (isInKnock && core.collisionSense.CheckTouchGround() && core.movement.rb.velocity.y < 0.1f)
        {
            core.movement.canMove = true;
            isInKnock = false;
        }
    }
}
