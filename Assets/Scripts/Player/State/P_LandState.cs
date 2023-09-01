using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_LandState : P_GroundState
{
    protected bool isLandFinish = false;
    public P_LandState(PlayerMachine playerMachine, Player player, PlayerData playerData) : base(playerMachine, player, playerData)
    {
        
    }
    public override void Enter()
    {
        base.Enter();
        player.animator.SetBool("isLand", true);
    }
    public override void Exit()
    {
        base.Exit();
        player.animator.SetBool("isLand", false);
    }
    public override void LogicUpdate()
    {
        if(isInState)
        {
            if(inputX != 0)
            {
                playerMachine.ChangeState(PlayerStateId.Move);
            }
            else if(isLandFinish)
            {
                playerMachine.ChangeState(PlayerStateId.Idle);
            }
        }
    }
    public override void AnimationFinish()
    {
        isLandFinish = true;
    }
}
