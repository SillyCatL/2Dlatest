using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected Core core;
    protected Player player;
    protected float startTime;
    protected PlayerMachine playerMachine;
    protected PlayerData playerData;
    protected bool isInState; //保证状态已经在转换时候 不再进行其他的logicUpdate判断操作

    public PlayerState(PlayerMachine playerMachine, Player player,PlayerData playerData)
    {
        this.playerMachine = playerMachine;
        this.player = player;
        this.playerData = playerData;
    }

    public virtual void Enter()
    {
        core = player.core;

        GetCheckVal();
        startTime = Time.time;
        isInState = true;
    }

    public virtual void Exit()
    {
        isInState = false;
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {
        GetCheckVal();
    }

    public virtual void GetCheckVal()
    {

    }

    public virtual void AnimationTrigger() { }
    public virtual void AnimationFinish() { }

}
