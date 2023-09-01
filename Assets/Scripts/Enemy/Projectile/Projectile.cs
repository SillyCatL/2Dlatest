using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private LayerMask ground;
    [SerializeField]
    private LayerMask player;
    [SerializeField]
    private Transform damagePosition;
    [SerializeField]
    private float damageRadius;
    [SerializeField]
    private float gravity;

    private bool isGravity;
    private bool isHitGround;
    private float speed;
    private float survivalTime = 2f;
    private float travelDis;
    private float BeginX;
    private Rigidbody2D rb;
    private bool isDamaged; //判断是否已经伤害过玩家



    public void Begin()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.velocity = transform.right * speed;
        isGravity = false;
        BeginX = transform.position.x;
    }

    private void FixedUpdate()
    {
        if (!isHitGround)
        {
            if (isGravity)
            {
                rb.gravityScale = gravity;
                //rad2Deg是弧度转换到角度的常量
                float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }
        //销毁物体
        else if (isHitGround)
        {
            if (survivalTime <= 0)
            {
                Destroy(gameObject);
            }
            else
                survivalTime -= Time.deltaTime;
        }
    }

    private void Update()
    {
        if (!isHitGround)
        {
            Collider2D groundCheck = Physics2D.OverlapCircle(damagePosition.position, damageRadius, ground);

            if (groundCheck != null)
            {
                isHitGround = true;
                rb.gravityScale = 0f;
                rb.velocity = Vector2.zero;
            }

            if (MathF.Abs(BeginX - transform.position.x) > travelDis)
            {
                isGravity = true;
            }
        }
    }

    public void FireProjectile(float speed, float travelDis)
    {
        this.speed = speed;
        this.travelDis = travelDis;
        isDamaged = false;
        Begin();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(damagePosition.position, damageRadius);
    }



    //伤害玩家
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isDamaged)
            return;
        if (other.CompareTag("Player"))
        {
            IDamageable damageable = other.gameObject.GetComponentInChildren<IDamageable>();

            if (damageable != null)
            {
                damageable.Damage(1);
                damageable.KnockBack(new Vector2(1, 1), 10f, (int)transform.right.x);
                isDamaged = true;
            }
        }
    }
}


