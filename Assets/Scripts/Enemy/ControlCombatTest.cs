using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCombatTest : MonoBehaviour,IDamageable
{
    public Animator animator{ get; private set; }
    public GameObject hitParticle;
    private void Awake() {
        animator = GetComponent<Animator>();
    }
    public void Damage(float damage)
    {
        Debug.Log(damage);
        Destroy(gameObject);
    }

    public void KnockBack(Vector2 angle, float strength, int direction)
    {
        throw new System.NotImplementedException();
    }
}
