using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Rendering.HybridV2;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{

    public Vector2 velocity;
    public Vector2 dashDirectionGet;
    public Vector2Int dashDirection;
    public bool[] attackArray;

    public bool Jump;
    public bool dashInput;
    public bool dashStop;
    public bool JumpStop;
    public int inputY;
    public int inputX;
    public bool grab;

    /// <summary>
    /// 冲刺操作和Jump操作的保存时间
    /// </summary>
    public float JumpNewTime;
    public float JumpHoldTime = 0f;
    public float dashNewTime;
    public float dashHoldTime = 0f;

    private void Awake()
    {
    }

    private void Start()
    {
        int count = Enum.GetValues(typeof(attackInput)).Length;

        attackArray = new bool[count];
    }
    private void Update()
    {

        CheckJumpHold();
        CheckDashHold();
    }

    private void CheckJumpHold()
    {
        if (Time.time > JumpNewTime + JumpHoldTime)
            Jump = false;
    }    
    private void CheckDashHold()
    {
        if (Time.time > dashNewTime + dashHoldTime)
            dashInput = false;
    }
    public void OnMove(InputAction.CallbackContext callbackContext)
    {
        velocity = callbackContext.ReadValue<Vector2>();
        velocity = velocity.normalized;
        inputX = (int)velocity.x;
        inputY = (int)velocity.y;
    }

    public void OnJump(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.started)
        {
            Jump = true;
            JumpStop = false;
            JumpNewTime = Time.time;
        }
        if (callbackContext.canceled)
        {
            JumpStop = true;
        }
    }

    public void OnGrab(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.started)
            grab = true;
        if (callbackContext.canceled)
            grab = false;
    }

    public void OnDash(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.started)
        {
            dashInput = true;
            dashNewTime = Time.time;
            dashStop = false;
        }
        if (callbackContext.canceled)
        {
            dashStop = true;
        }
    }
    public void OnDashDirction(InputAction.CallbackContext callbackContext)
    {
        dashDirectionGet = callbackContext.ReadValue<Vector2>();

        dashDirectionGet = Camera.main.ScreenToWorldPoint(dashDirectionGet) - transform.position;

        //将dash的方向固定到8个方向
        dashDirection = Vector2Int.RoundToInt(dashDirectionGet.normalized);
    }

    //攻击检测
    public void OnPrimaryAttack(InputAction.CallbackContext callbackContext)
    {
        if(callbackContext.started)
        {
            attackArray[(int)attackInput.primaryAttack] = true;
        }
        if(callbackContext.canceled)
        {
            attackArray[(int)attackInput.primaryAttack] = false;
        }
    }
    public void OnSecondAttack(InputAction.CallbackContext callbackContext)
    {
        if(callbackContext.started)
        {
            attackArray[(int)attackInput.secondAttack] = true;
        }
        if(callbackContext.canceled)
        {
            attackArray[(int)attackInput.secondAttack] = false;
        }
    }

    
    public void UseJump()
    {
        Jump = false;
    }
    public void UseDash()
    {
        dashInput = false;
    }

    public enum attackInput
    {
        primaryAttack,
        secondAttack
    }

}
