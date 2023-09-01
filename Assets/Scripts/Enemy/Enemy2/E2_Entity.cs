using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_Entity : BaseEntityEnemy
{
    public E2_Dead e2_Dead;
    public E2_Idle e2_Idle;
    public E2_LookFor e2_LookFor;
    public E2_MeeleAttack e2_MeeleAttack;
    public E2_Stun e2_Stun;
    public E2_Walk e2_Walk;
    public E2_PlayerDetected e2_PlayerDetected;
    public E2_Dodge e2_Dodge;
    public E2_LongAttack e2_LongAttack;

    public D_Dodge d_Dodge;
    public D_LongAttack d_LongAttack;


    protected override void Awake()
    {
        base.Awake();
        e2_Dead = new E2_Dead(this, baseFSM, d_Dead);
        e2_Idle = new E2_Idle(this, baseFSM, d_IdleState);
        e2_LookFor = new E2_LookFor(this, baseFSM, d_LookForPlayer);
        e2_Walk = new E2_Walk(this, baseFSM, d_WalkState);
        e2_PlayerDetected = new E2_PlayerDetected(this, baseFSM, d_PlayerDetected);
        e2_Stun = new E2_Stun(this, baseFSM, d_Stun);
        e2_MeeleAttack = new E2_MeeleAttack(this, baseFSM, attackClosePos, d_MeeleAttack);
        e2_Dodge = new E2_Dodge(this, baseFSM, d_Dodge);
        e2_LongAttack = new E2_LongAttack(this, baseFSM, attackClosePos, d_LongAttack);

        baseFSM.state_dictionary.Add(StateId.idle, e2_Idle);
        baseFSM.state_dictionary.Add(StateId.walk, e2_Walk);
        baseFSM.state_dictionary.Add(StateId.playerDetected, e2_PlayerDetected);
        baseFSM.state_dictionary.Add(StateId.lookForPlayer, e2_LookFor);
        baseFSM.state_dictionary.Add(StateId.meeleAttack, e2_MeeleAttack);
        baseFSM.state_dictionary.Add(StateId.Stun, e2_Stun);
        baseFSM.state_dictionary.Add(StateId.Dead, e2_Dead);
        baseFSM.state_dictionary.Add(StateId.Dodge, e2_Dodge);
        baseFSM.state_dictionary.Add(StateId.LongAttack, e2_LongAttack);
        baseFSM.Begin(StateId.walk);
    }
    private void Start() {
        baseFSM.Begin(StateId.walk); //写在Start中避免core等组件还没有获得就调用 begin函数
    }



    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.DrawWireSphere(attackClosePos.position, d_MeeleAttack.attackRadius);
    }
}
