using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    public void Damage(float damage);
    public void KnockBack(Vector2 angle, float strength, int direction);
}
