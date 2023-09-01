using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatModel : MonoBehaviour
{
    private GameObject alive, partUp, partDown;
    private PlayerController playerController;
    private Rigidbody2D rbAlive, rbUp, rbDown;
    private Animator aliveAnimator;
    [SerializeField]
    private float knockSpeedx,knockSpeedy,knockDeathSpeedx,knockDeathSpeedy,deathTorque;
    [SerializeField]
    private GameObject hitParticle;

    [SerializeField]
    private float knockTime,health;

    private float currentHealth;
    private float lastKnockTime;

    private float playerFace;
    private bool playerOnLeft;

    private void Start()
    {
        currentHealth = health;



        alive = transform.Find("Alive").gameObject;
        partUp = transform.Find("Part up").gameObject;
        partDown = transform.Find("Part down").gameObject;
        aliveAnimator = alive.GetComponent<Animator>();

        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        rbAlive = alive.GetComponent<Rigidbody2D>();
        rbUp = partUp.GetComponent<Rigidbody2D>();
        rbDown = partDown.GetComponent<Rigidbody2D>();

        alive.SetActive(true);
        partUp.SetActive(false);
        partDown.SetActive(false);
    }

    private void Update()
    {
        CheckIfKnock();
    }

    // private void Damage(AttackDetails attackDetails)
    // {
    //     currentHealth -= attackDetails.attackDamage;

    //     lastKnockTime = Time.time;
    //     playerFace = playerController.GetFaceDirection();

    //     ///攻击特效
    //     Instantiate(hitParticle,alive.transform.position,Quaternion.Euler(0,0, UnityEngine.Random.Range(0.0f, 360.0f)));
        
    //     if(playerFace == 1)
    //         playerOnLeft = false;
    //     else
    //         playerOnLeft = true;
    //     aliveAnimator.SetBool("playerOnLeft",playerOnLeft);
    //     aliveAnimator.SetTrigger("knock");

    //     if(currentHealth <= 0)
    //     {
    //         Die(); 
    //     }
    //     else
    //     {
    //         Knock();
    //     }
        
    // }

    private void Knock()
    {
        rbAlive.velocity = new Vector2(knockSpeedx * playerFace , knockSpeedy);
    }

    private void Die()
    {
        alive.SetActive(false);
        partUp.SetActive(true);
        partDown.SetActive(true);

        ///把上下半身的位置更新
        partDown.transform.position = alive.transform.position;
        partUp.transform.position = alive.transform.position;

        rbUp.velocity = new Vector2(knockSpeedx * playerFace,knockSpeedy);
        rbDown.velocity = new Vector2(knockDeathSpeedx * playerFace,knockDeathSpeedy);
        rbUp.AddTorque(-playerFace * deathTorque,ForceMode2D.Impulse);
    }

    private void CheckIfKnock()
    {
        ///受伤的反馈结束
        if (Time.time > lastKnockTime + knockTime)
        {
            rbAlive.velocity = new Vector2(0f, rbAlive.velocity.y);
        }
    }

}
