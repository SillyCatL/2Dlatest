using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSense : CoreComponent
{

    #region Check Trans
    public Transform groundTransform;
    public Transform wallTransform;
    public Transform LedgeTranfromPlayer;
    public Transform LedgeTranfromEnemy;
    #endregion

    public float groundCheckRadius;
    public float ledgeCheckDis;
    public float wallCheckDis;
    public LayerMask groundMask;

    protected override void Awake()
    {
        base.Awake();
    }

    #region Check Functions
    public bool CheckTouchGround()
    {
        return Physics2D.OverlapCircle(groundTransform.position, groundCheckRadius, groundMask);
    }

    public bool CheckLedgeForPlayer()
    {
        return Physics2D.Raycast(LedgeTranfromPlayer.position, core.movement.faceDirecion * Vector2.right, ledgeCheckDis, groundMask);
    }

    public bool CheckLedgeForEnemy()
    {
        return Physics2D.Raycast(LedgeTranfromEnemy.position, Vector2.down, ledgeCheckDis, groundMask);
    }

    public bool CheckWall()
    {
        return Physics2D.Raycast(wallTransform.position, core.movement.faceDirecion * Vector2.right, wallCheckDis, groundMask);
    }

    public bool CheckBackWall()
    {
        return Physics2D.Raycast(wallTransform.position, -core.movement.faceDirecion * Vector2.right, wallCheckDis, groundMask);
    }

    #endregion

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundTransform.position, groundCheckRadius);
        Gizmos.DrawLine(wallTransform.position, new Vector2(wallTransform.position.x + wallCheckDis, wallTransform.position.y));
    }
}
