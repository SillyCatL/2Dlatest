using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class P_AttackState : P_AbilityState
{
    public Weapon weapon;

    protected float moveVelocity;
    protected bool isMove;
    protected int xInput;
    protected bool isFlip;

    public P_AttackState(PlayerMachine playerMachine, Player player, PlayerData playerData) : base(playerMachine, player, playerData)
    {
    }
    public override void Enter()
    {
        base.Enter();

        isMove = false;
        player.animator.SetBool("attack", true);
        weapon.EnterWeapon();
    }

    public override void Exit()
    {
        base.Exit();


        player.animator.SetBool("attack", false);
        weapon.ExitWeapon();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        CheckFlip();

        if(isMove)
        {
            core.movement.SetVelocityX(moveVelocity * core.movement.faceDirecion);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

    }

    public override void GetCheckVal()
    {
        base.GetCheckVal();
        xInput = player.playerInput.inputX;
    }

    public virtual void SitWeapon(Weapon weapon,Core core)
    {
        this.weapon = weapon;
        this.weapon.Initialize(this,core);
    }

    public virtual void SetMoveVelocity(float velocity)
    {
        core.movement.SetVelocityX(velocity * core.movement.faceDirecion);
        moveVelocity = velocity;

        isMove = true;
    }
    public virtual void CheckFlip()
    {
        if(isFlip)
        {
            core.movement.CheckCanFlip(xInput);
        }
    }
    public virtual void SetFlip(bool flip)
    {
        isFlip = flip;
    }
    public override void AnimationFinish()
    {
        base.AnimationFinish();

        isAbilityOver = true;
    }
}
