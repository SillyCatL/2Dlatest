using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rg;
    private Animator animator;

    private float faceDirection = 1;
    private float inputDirection;
    //下墙延迟
    private float turnTimeSet = 0.1f;
    private float turnTime;
    private bool canMove;
    private bool canFlip;

    private bool faceRight = true;
    private bool isWalk;
    private bool isWallSliding;
    private bool isGround;
    private bool isTouchWall;
    private bool canNormalJump;
    private bool canWallJump;
    private bool isWallJumpTime;
    private bool canClimb;
    private bool isTouchLegle;

    //爬墙判断
    private Vector2 legleCheckPos;
    private Vector2 legleClimbPos1;
    private Vector2 legleClimbPos2;
    public Vector2 legleCheckOffset;
    public Vector2 LegleOffset1;
    public Vector2 LegleOffset2;


    ///冲刺
    private float lastDashTime;
    private bool isDashing;
    private float dashLeftTime;
    private Vector3 lastImagePos;
    [Header("冲刺设置")]
    public float distanceBetweenImage;
    public float dashTime;
    public float dashSpeed;
    public float dashCoolTime;


    public LayerMask ground;
    public Vector2 groundCheckOffset;
    public Vector2 wallCheckOffset;

    public float moveSpeed;
    public float jumpForce;
    public float moveInAirForce;
    public float slidingSpeed;
    public float groundCheckRadius;
    public float wallCheckDistance;

    public Vector2 wallJumpDirection;
    public float wallJumpForce;

    [Header("调节动作")]
    public float airDragMultiplier = 0.95f;
    public float jumpVariableForce = 0.5f;

    private void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        wallJumpDirection.Normalize();
    }

    private void FixedUpdate()
    {
        Move();
    }
    private void Update()
    {
        CheckInput();

        ///注意这两个的先后顺序
        CheckIfWallJumpTime();
        CheckFaceDirection();

        CheckSurroundings();
        CheckCanJump();
        CheckTurnTime();
        CheckIfWallSliding();

        CheckIfCanClimb();
        LegleClimb();

        CheckDash();

        UpdateAnimation();
    }

    /// <summary>
    /// 冲刺检测
    /// </summary>
    private void CheckDash()
    {
        if (!isDashing)
            return;
        if (dashLeftTime >= 0)
        {
            dashLeftTime -= Time.deltaTime;
            rg.velocity = new Vector2(dashSpeed * faceDirection, 0);
            if (Mathf.Abs(transform.position.x - lastImagePos.x) > distanceBetweenImage)
            {
                ImageObjectPool.Instance.GetFromPool();
                lastImagePos = transform.position;
            }

            canMove = false;
            canFlip = false;
        }
        else if (dashLeftTime < 0 || isTouchWall == true)
        {
            isDashing = false;
            canMove = true;
            canFlip = true;
        }
    }

    /// <summary>
    /// 检测蹬墙跳后是否还是蹬墙跳跃时间（无法移动）
    /// </summary>
    private void CheckIfWallJumpTime()
    {
        if ((faceRight && inputDirection < -0.1f) || (!faceRight && inputDirection > 0.1f))
        {
            isWallJumpTime = false;
        }
        else if (rg.velocity.y <= 0.1f)
        {
            isWallJumpTime = false;
        }
    }

    /// <summary>
    /// 判断是否可以下墙
    /// </summary>
    private void CheckTurnTime()
    {
        if (turnTime >= 0)
        {
            turnTime -= Time.deltaTime;
            if (turnTime < 0)
            {
                canMove = true;
                canFlip = true;
            }
        }
    }

    /// <summary>
    /// 判断能否爬上墙
    /// </summary>
    private void CheckIfCanClimb()
    {
        if (!isTouchLegle && isTouchWall && !canClimb)
        {
            canClimb = true;
            legleCheckPos = (Vector2)transform.position + wallCheckOffset;
        }
    }


    /// <summary>
    /// 爬墙操作
    /// </summary>
    private void LegleClimb()
    {
        if (!canClimb)
            return;

        canMove = false;
        canFlip = false;

        //legleClimbPos1在攀爬墙壁时对动画播放位置判断，legleClimPos2为结束动画时应该在的位置
        //Floor和Celling对不同触发位置产生相同的动画位置偏移
        if (faceRight)
        {
            legleClimbPos1 = new Vector2(MathF.Floor(legleCheckPos.x + wallCheckDistance) - LegleOffset1.x, MathF.Floor(legleCheckPos.y) + LegleOffset1.y);
            legleClimbPos2 = new Vector2(MathF.Floor(legleCheckPos.x + wallCheckDistance) + LegleOffset2.x, MathF.Floor(legleCheckPos.y) + LegleOffset2.y);
        }
        else
        {
            legleClimbPos1 = new Vector2(MathF.Ceiling(legleCheckPos.x - wallCheckDistance) + LegleOffset1.x, MathF.Floor(legleCheckPos.y) + LegleOffset1.y);
            legleClimbPos2 = new Vector2(MathF.Ceiling(legleCheckPos.x - wallCheckDistance) - LegleOffset1.x, MathF.Floor(legleCheckPos.y) + LegleOffset2.y);
        }

        transform.position = legleClimbPos1;
    }

    /// <summary>
    /// 外部接口动画结束帧调用
    /// </summary>
    public void FinishedClimb()
    {
        transform.position = (Vector3)legleClimbPos2;
        canClimb = false;
        canMove = true;
        canFlip = true;
    }

    public float GetFaceDirection()
    {
        return faceDirection;
    }

    /// <summary>
    /// 滑墙判断
    /// </summary>
    private void CheckIfWallSliding()
    {
        if (!isGround && isTouchWall && inputDirection == faceDirection && rg.velocity.y < 0 && !canClimb)
            isWallSliding = true;
        else if (isTouchWall == false || isGround == true)
            isWallSliding = false;
    }

    /// <summary>
    /// 检测能否跳跃
    /// </summary>
    private void CheckCanJump()
    {
        if (isGround)
            canNormalJump = true;
        else
            canNormalJump = false;

        if (isTouchWall)
            canWallJump = true;
        else
            canWallJump = false;
    }

    private void CheckSurroundings()
    {
        isTouchWall = Physics2D.Raycast((Vector2)transform.position + wallCheckOffset, transform.right, wallCheckDistance, ground);
        isGround = Physics2D.OverlapCircle((Vector2)transform.position + groundCheckOffset, groundCheckRadius, ground);
        isTouchLegle = Physics2D.Raycast((Vector2)transform.position + legleCheckOffset, transform.right, wallCheckDistance, ground);
    }

    private void SelectJumpMode()
    {
        if (isWallSliding)
            WallJump();
        else if (isGround)
            NormalJump();
    }

    /// <summary>
    /// 普通跳跃
    /// </summary>
    private void NormalJump()
    {
        if (!canNormalJump)
            return;

        rg.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    /// <summary>
    /// 蹬强跳
    /// </summary>
    private void WallJump()
    {
        if (!canWallJump)
            return;

        isWallJumpTime = true;
        rg.velocity = new Vector2(0, 0);
        Vector2 forceNew = new(wallJumpForce * wallJumpDirection.x * -faceDirection, wallJumpForce * wallJumpDirection.y);
        rg.AddForce(forceNew, ForceMode2D.Impulse);
    }

    /// <summary>
    /// 动画更新
    /// </summary>
    private void UpdateAnimation()
    {
        animator.SetBool("IsGround", isGround);
        animator.SetBool("IsWalk", isWalk);
        animator.SetBool("isWallSliding", isWallSliding);
        animator.SetFloat("yVelocity", rg.velocity.y);
        animator.SetBool("isClimb", canClimb);
    }

    /// <summary>
    /// 人物移动
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    private void Move()
    {
        ///移动
        if (!isGround && !isWallSliding && inputDirection == 0)///空中移动距离改变 airDragMultiplier
        {
            rg.velocity = new Vector2(rg.velocity.x * airDragMultiplier, rg.velocity.y);
        }
        else if (canMove && !isWallJumpTime)///普通移动
        {
            rg.velocity = new Vector2(inputDirection * moveSpeed, rg.velocity.y);
        }

        ///滑墙移动
        if (isWallSliding == true)
        {
            if (rg.velocity.y < -slidingSpeed)
                rg.velocity = new Vector2(rg.velocity.x, -slidingSpeed);
        }
    }

    /// <summary>
    /// 检测输入
    /// </summary>
    private void CheckInput()
    {
        inputDirection = Input.GetAxisRaw("Horizontal");

        ///判断跳跃
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SelectJumpMode();
        }

        ///判断下墙，
        if (Input.GetButtonDown("Horizontal") && isTouchWall)
        {
            if (!isGround && inputDirection != faceDirection)
            {
                canMove = false;
                canFlip = false;
                turnTime = turnTimeSet;
            }
        }

        ///判断跳跃高度 jumpVariableForce
        if (Input.GetKeyUp(KeyCode.Space))
        {
            rg.velocity = new Vector2(rg.velocity.x, rg.velocity.y * jumpVariableForce);
        }

        ///判断移动
        if (Mathf.Abs(rg.velocity.x) > 0.1f)
        {
            isWalk = true;
        }
        else
            isWalk = false;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            AttemptToDash();
        }
    }

    private void AttemptToDash()
    {
        if (Time.time < lastDashTime + dashCoolTime)
            return;
        isDashing = true;
        lastDashTime = Time.time;
        dashLeftTime = dashTime;
        lastImagePos = transform.position;
    }

    /// <summary>
    /// 检测朝向
    /// </summary>
    private void CheckFaceDirection()
    {
        if ((faceRight && inputDirection < 0) || (!faceRight && inputDirection > 0))
        {
            if (!isTouchWall)
            {
                if (!canFlip)
                    return;
                Flip();
            }
        }
    }

    /// <summary>
    /// 翻转
    /// </summary>
    private void Flip()
    {
        faceDirection = -faceDirection;
        faceRight = !faceRight;
        transform.Rotate(0f, 180f, 0f);
    }

    /// <summary>
    /// 射线显示
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere((Vector2)transform.position + groundCheckOffset, groundCheckRadius);
        Gizmos.DrawLine((Vector2)transform.position + wallCheckOffset, new Vector2(transform.position.x + wallCheckOffset.x + (faceRight ? wallCheckDistance : -wallCheckDistance), transform.position.y + wallCheckOffset.y));
        Gizmos.DrawLine((Vector2)transform.position + legleCheckOffset, new Vector2(transform.position.x + legleCheckOffset.x + (faceRight ? wallCheckDistance : -wallCheckDistance), transform.position.y + legleCheckOffset.y));
    }
}
