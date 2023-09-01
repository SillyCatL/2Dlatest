using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Player Date/PlayerData")]
public class PlayerData : ScriptableObject
{
    public float moveVelocity;
    public float JumpForce;

    [Header("In Air")]
    public float coyoteTime;
    public float jumpBanForce = -0.1f;

    [Header("WallCheck")]
    public float slideVelocity = -3f;
    public float wallClimbVelocity = 2f;

    [Header("WallJump")]
    public float wallJumpForce;
    public Vector2 wallJumpAngle;
    public float wallJumpTime;

    [Header("Ledge")]
    public float ledgeCheckDis;
    public Vector2 ledgeHoldOffset;
    public Vector2 ledgeFinishOffset;

    [Header("Dash")]
    public float dashCoolTime = 0.5f;
    public float dashHoldTime = 1f;
    public float dashHoldScaleTime = 0.25f;
    public float dashTime = 0.2f;
    public float dashVelocity = 30f;
    public float drag = 10f;
    public float dashEndMultiplier = 0.2f;
    public float disBetweenAfterImages = 0.5f;
}

