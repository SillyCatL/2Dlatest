using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    protected Core core;
    protected Animator weaponAnimator;
    protected Animator baseAnimator;

    public WeaponData weaponData;
    public P_AttackState p_AttackState;

    protected int attackCount;

    protected virtual void Awake()
    {
        weaponAnimator = transform.Find("Weapon").GetComponent<Animator>();
        baseAnimator = transform.Find("Base").GetComponent<Animator>();
    }

    public virtual void EnterWeapon()
    {
        
        gameObject.SetActive(true); //要放在最前，避免妨碍其他代码运行


        if(attackCount >= weaponData.attackCount)
        {
            attackCount = 0;
            weaponAnimator.SetInteger("attackCount", 0);
            baseAnimator.SetInteger("attackCount", 0);
        }

        weaponAnimator.SetBool("attack", true);
        baseAnimator.SetBool("attack", true);
        
        weaponAnimator.SetInteger("attackCount", attackCount);
        baseAnimator.SetInteger("attackCount", attackCount);
    }

    public virtual void ExitWeapon()
    {
        attackCount++;

        weaponAnimator.SetBool("attack", false);
        baseAnimator.SetBool("attack", false);

        gameObject.SetActive(false);
    }

    public virtual void AnimationFinish()
    {
        p_AttackState.AnimationFinish();
    }

    public virtual void AnimationMoveSpeedTrigger()
    {
        p_AttackState.SetMoveVelocity(weaponData.attackMoveSpeed[attackCount]);
    }
    
    public virtual void AnimationMoveStopTrigger()
    {
        p_AttackState.SetMoveVelocity(0f);  
    }
    public virtual void AnimationFlipOnTrigger()
    {
        p_AttackState.SetFlip(true);
    }
    public virtual void AnimationFlipOffTrigger()
    {
        p_AttackState.SetFlip(false);
    }

    public virtual void AnimationActionTrriger()
    {
           
    }

    public void Initialize(P_AttackState p_AttackStat,Core core)
    {
        this.p_AttackState = p_AttackStat;
        this.core = core;
    }   

}
