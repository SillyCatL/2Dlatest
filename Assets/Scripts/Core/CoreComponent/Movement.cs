using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : CoreComponent
{
    public Rigidbody2D rb { get; private set; }
    public int faceDirecion { get; set; }
    public bool canMove { get;set;}

protected override void Awake()
{
    base.Awake();

    canMove = true;
    rb = GetComponentInParent<Rigidbody2D>();
    faceDirecion = 1;
}
public void SetVelocityX(float velocity)
{
    if (canMove)
        rb.velocity = new Vector2(velocity, rb.velocity.y);
}
public void SetVelocityY(float velocity)
{
    if (canMove)
        rb.velocity = new Vector2(rb.velocity.x, velocity);
}

public void SetVelocityZero()
{
    if (canMove)
        rb.velocity = new Vector2(0, 0);
}

public void SetVelocity(float velocity, Vector2 angle, int dir)
{
    angle = angle.normalized;
    if (canMove)
        rb.velocity = new Vector2(velocity * angle.x * dir, velocity * angle.y);
}

public void SetVelocity(float velocity, Vector2 direction)
{
    if (canMove)
        rb.velocity = new Vector2(velocity * direction.x, velocity * direction.y);
}

public void CheckCanFlip(int inputX)
{
    if (faceDirecion != inputX && inputX != 0)
        SetFlip();
}
public void SetFlip()
{
    faceDirecion *= -1;
    rb.transform.Rotate(0, 180, 0);
}
}
