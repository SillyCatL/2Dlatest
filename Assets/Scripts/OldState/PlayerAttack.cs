// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerAttack : MonoBehaviour
// {
//     public bool canAttack;
//     private Animator animator;
//     private bool gotMouseDown;
//     private bool isAttacking;

//     public float timeAttackBetween;
//     publ ic AttackDetails attackDetails;
//     private float lastTime = -100;

//     public Transform attack1HitBoxPos;
//     public float attack1Radius;
//     public LayerMask whatIsDamageable;

//     private void Start()
//     {
//         animator = GetComponent<Animator>();
//         attackDetails.attackDamage = 1;
//         attackDetails.attackHop = 10;
//         attackDetails.attackPos = transform;;
//         attackDetails.attackStunAmount = 1;
//     }


//     private void Update()
//     {
//         CheckAttackInput();
//         CheckAttack();
//         UpdateAnimation();
//     }

//     private void UpdateAnimation()
//     {
//         animator.SetBool("isAttacking", isAttacking);
//         animator.SetBool("canAttack",canAttack);
//     }

//     private void CheckAttackInput()
//     {
//         if (Input.GetMouseButtonDown(0))
//         {
//             gotMouseDown = true;
//         }
//     }

//     private void CheckAttack()
//     {
//         if (gotMouseDown == true)
//         {
//             if (!isAttacking)
//             {
//                 gotMouseDown = false;
//                 isAttacking = true;
//             }
//             animator.SetTrigger("attack");
//         }

//         ///输入攻击时间间隔，主要用于改变setTrigger(attack)        
//         if (Time.time > lastTime + timeAttackBetween)
//             gotMouseDown = false;
//     }

//     /// <summary>
//     /// 外部接口完成攻击
//     /// </summary>
//     public void FinishedAttack()
//     {
//         isAttacking = false;
//     }

//     /// <summary>
//     /// 检测攻击到的敌人
//     /// </summary>
//     private void CheckAttackHitBox()
//     {
//         Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attack1HitBoxPos.position, attack1Radius, whatIsDamageable);

//         foreach (Collider2D collider in detectedObjects)
//         {
//             ///执行Damage函数
//             collider.transform.parent.SendMessage("Damage", attackDetails);
//         }
//     }

//     private void OnDrawGizmos()
//     {
//         Gizmos.DrawWireSphere(attack1HitBoxPos.position, attack1Radius);
//     }

// }  
