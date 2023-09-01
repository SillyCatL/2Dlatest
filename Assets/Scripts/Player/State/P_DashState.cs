using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem.Interactions;

public class P_DashState : P_AbilityState
{
    protected bool canDash; //检测什么时候可以冲刺
    protected float lastDashTime;
    protected bool isHolding;

    protected PlayerStateId animationId;

    protected Vector2 lastPos;

    protected Vector2 dashDirection;
    protected bool dashStop;
    public P_DashState(PlayerMachine playerMachine, Player player, PlayerData playerData) : base(playerMachine, player, playerData)
    {

    }

    public override void Enter()
    {
        base.Enter();

        canDash = false;
        isHolding = true;
        player.playerInput.UseDash();

        player.animator.SetBool("isInAir", true);

        Time.timeScale = playerData.dashHoldScaleTime;
        startTime = Time.unscaledTime;

        player.DashDirectionIndicator.gameObject.SetActive(true);

    }

    public bool CheckCanDash()
    {
        return canDash && Time.time > lastDashTime + playerData.dashCoolTime;
    }

    public void ResetDash() => canDash = true;

    public void GetAnimation(PlayerStateId id)
    {
        animationId = id;
    }

    public override void Exit()
    {
        base.Exit();

        player.animator.SetBool("isInAir", false);

        //检测是否冲刺完毕，进行降速
        if(player.rb.velocity.y > 0)
        {
            core.movement.SetVelocityY(playerData.dashEndMultiplier * player.rb.velocity.y);
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isInState)
        {
            player.animator.SetFloat("yVelocity", player.rb.velocity.y);
            player.animator.SetFloat("xVelocity", MathF.Abs(player.rb.velocity.x));

            if (isHolding)
            {
                dashDirection = player.playerInput.dashDirection;
                dashStop = player.playerInput.dashStop;

                float angle = Vector2.SignedAngle(Vector2.right, dashDirection);
                player.DashDirectionIndicator.rotation = Quaternion.Euler(0f, 0f, angle - 45f); //45是图片本身的旋转角度

                if (dashStop || Time.unscaledTime > startTime + playerData.dashHoldTime)
                {
                    isHolding = false;
                    Time.timeScale = 1f;
                    player.DashDirectionIndicator.gameObject.SetActive(false);

                    startTime = Time.time;
                    //阻力
                    player.rb.drag = playerData.drag;

                    core.movement.CheckCanFlip(Mathf.RoundToInt(dashDirection.x));


                    core.movement.SetVelocity(playerData.dashVelocity, dashDirection);

                }
            }
            else
            {
                CheckIfImage();
                if (Time.time > startTime + playerData.dashTime)
                {
                    lastDashTime = Time.time;
                    player.rb.drag = 0f;
                    isAbilityOver = true;
                }
            }
        }
    }

    private void CheckIfImage()
    {
        if(Vector2.Distance(player.transform.position,lastPos) >= playerData.disBetweenAfterImages)
        {
            GetAfterImage();
        }
    }

    private void GetAfterImage()
    {
        ImageObjectPool.Instance.GetFromPool();
        lastPos = player.transform.position;
    }


    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void GetCheckVal()
    {
        base.GetCheckVal();
    }

}
