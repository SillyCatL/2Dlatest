using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_Entity : BaseEntityEnemy
{
    public E1_IdleState e1_IdleState;
    public E1_WalkState e1_WalkState;
    public E1_PlayerDetected e1_PlayerDetected;
    public E1_Judge e1_Judge;
    public E1_LooForPlayer e1_LooForPlayer;
    public E1_MeeleAttack e1_MeeleAttack;
    public E1_StunState e1_Stun;
    public E1_Dead e1_Dead;
    protected override void Awake()
    {
        base.Awake();
        e1_IdleState = new E1_IdleState(this, baseFSM, d_IdleState);
        e1_WalkState = new E1_WalkState(this, baseFSM, d_WalkState);
        e1_PlayerDetected = new E1_PlayerDetected(this, baseFSM, d_PlayerDetected);
        e1_Judge = new E1_Judge(this, baseFSM, d_Judge);
        e1_LooForPlayer = new E1_LooForPlayer(this, baseFSM, d_LookForPlayer);
        e1_MeeleAttack = new E1_MeeleAttack(this, baseFSM, attackClosePos, d_MeeleAttack);
        e1_Stun = new E1_StunState(this, baseFSM, d_Stun);
        e1_Dead = new E1_Dead(this, baseFSM, d_Dead);

        baseFSM.state_dictionary.Add(StateId.idle, e1_IdleState);
        baseFSM.state_dictionary.Add(StateId.walk, e1_WalkState);
        baseFSM.state_dictionary.Add(StateId.playerDetected, e1_PlayerDetected);
        baseFSM.state_dictionary.Add(StateId.judge, e1_Judge);
        baseFSM.state_dictionary.Add(StateId.lookForPlayer, e1_LooForPlayer);
        baseFSM.state_dictionary.Add(StateId.meeleAttack, e1_MeeleAttack);
        baseFSM.state_dictionary.Add(StateId.Stun, e1_Stun);
        baseFSM.state_dictionary.Add(StateId.Dead, e1_Dead);
    }

    private void Start() {
        
        baseFSM.Begin(StateId.walk); //写在Start中避免begin时core等组件还没有获取完毕
    }



    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.DrawWireSphere(attackClosePos.position, d_MeeleAttack.attackRadius);
    }
}
