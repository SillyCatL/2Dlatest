using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using System.Linq;

public class AggresiveWeapon : Weapon
{
    protected List<IDamageable> idamage = new List<IDamageable>();
    protected AggresiveWeaponData aggresiveWeaponData;

    protected override void Awake()
    {
        base.Awake();
        if (weaponData.GetType() == typeof(AggresiveWeaponData))
            aggresiveWeaponData = (AggresiveWeaponData)weaponData;
    }
    public override void AnimationActionTrriger()
    {
        base.AnimationActionTrriger();
        CheckMeleeAttack();
    }

    private void CheckMeleeAttack()
    {
        WeaponAttackDetails details = aggresiveWeaponData.weaponAttackDetails[attackCount];

        foreach (IDamageable i in idamage.ToList())//tolist让循环对idamage副本访问，idamage的更改不影响循环
        {
            i.Damage(details.attackDamage);
            i.KnockBack(details.knockAngle, details.knockStrength, core.movement.faceDirecion);

        }
    }

    public void AddToCollision(Collider2D collision2D)
    {
        IDamageable idamageable = collision2D.transform.GetComponentInChildren<IDamageable>();

        if (idamageable != null)
        {
            idamage.Add(idamageable);
        }
    }

    public void RemoveCollisin(Collider2D collider2D)
    {
        IDamageable idamageable = collider2D.transform.GetComponentInChildren<IDamageable>();

        if (idamageable != null)
        {
            idamage.Remove(idamageable);
        }
    }
}
