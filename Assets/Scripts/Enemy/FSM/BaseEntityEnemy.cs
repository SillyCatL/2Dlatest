using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEntityEnemy : MonoBehaviour
{
    public BaseFSM baseFSM;
    public Core core { get; private set; }
    public Animator animator { get; private set; }

    public D_IdleState d_IdleState;
    public D_WalkState d_WalkState;
    public D_PlayerDetected d_PlayerDetected;
    public D_Entity d_Entity;
    public D_Judge d_Judge;
    public D_LookForPlayer d_LookForPlayer;
    public D_MeeleAttack d_MeeleAttack;
    public D_Stun d_Stun;
    public D_Dead d_Dead;

    [SerializeField]
    protected Transform wallCheckPos;
    [SerializeField]
    protected Transform ledgeCheckPos;
    [SerializeField]
    protected Transform playerDetectPos;
    [SerializeField]
    protected Transform attackClosePos;
    [SerializeField]
    protected Transform groundCheckPos;

    public GameObject hitParticle;
    public AnimationInfer animationInfer { get; private set; }

    protected float currentHealth;
    protected float currentStunAnti;

    protected bool isStun;
    protected bool isDead;
    public int attackFromRight { get; private set; }


    protected virtual void Awake()
    {
        core = GetComponentInChildren<Core>();

        baseFSM = new BaseFSM();

        animationInfer = GetComponent<AnimationInfer>();

        animator = GetComponent<Animator>();

        currentHealth = d_Entity.health;

        currentStunAnti = d_Entity.stunAnit;

        isStun = false;
    }


    public virtual void Update()
    {
        baseFSM.currentState.LogicUpdate();
    }

    public virtual void FixedUpdate()
    {
        baseFSM.currentState.PhysicsUpdate();
    }

    /// <summary>
    /// 各种检测函数
    /// </summary>
    /// <returns></returns>
    public virtual bool CheckPlayerInMinAggroRange()
    {
        return Physics2D.Raycast(playerDetectPos.position, transform.right, d_Entity.playerAggroMinRange, d_Entity.player);
    }
    public virtual bool CheckPlayerInMaxAggroRange()
    {
        return Physics2D.Raycast(playerDetectPos.position, transform.right, d_Entity.playerAggroMaxRange, d_Entity.player);
    }

    public virtual bool CheckPlayerInCloseAttackRange()
    {
        return Physics2D.Raycast(playerDetectPos.position, transform.right, d_Entity.attackCloseCheckDis, d_Entity.player);
    }


    /// <summary>
    /// 受伤调用
    /// </summary>
    /// <param name="attackDetails"></param>
    // public virtual void Damage(AttackDetails attackDetails)
    // {
    //     currentHealth -= attackDetails.attackDamage;

    //     currentStunAnti -= attackDetails.attackStunAmount;

    //     Instantiate(hitParticle, transform.position, Quaternion.Euler(0, 0, UnityEngine.Random.Range(0.0f, 360.0f)));

    //     DamageKnock(attackDetails.attackHop);

    //     if (attackDetails.attackPos.position.x > transform.position.x)
    //     {
    //         attackFromRight = 1;
    //     }
    //     else
    //     {
    //         attackFromRight = -1;
    //     }
    //     isStun = currentStunAnti == 0 ? true : false;
    //     isDead = currentHealth == 0 ? true : false;

    // }

    public virtual void DamageKnock(float attackHop)
    {
        core.movement.rb.velocity = new Vector2(core.movement.rb.velocity.x, attackHop);
    }

    public virtual void ResetStun()
    {
        currentStunAnti = d_Entity.stunAnit;
        isStun = false;
    }



    public virtual void Flip()
    {
        core.movement.faceDirecion *= -1;
        transform.Rotate(0, 180, 0);
    }

    protected virtual void OnDrawGizmos()
    {
        if(core != null)
        {
            Gizmos.DrawLine(wallCheckPos.position, new Vector2(wallCheckPos.position.x + (core.movement.faceDirecion == 1 ? d_Entity.wallCheckDis : d_Entity.wallCheckDis), wallCheckPos.position.y));
            Gizmos.DrawLine(ledgeCheckPos.position, new Vector2(ledgeCheckPos.position.x, ledgeCheckPos.position.y + d_Entity.ledgeCheckDis));

            Gizmos.DrawWireSphere(groundCheckPos.position, d_Entity.groundCheckRadius);
        }
    }
}
