using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "EntityData", menuName = "Data/Enemy Date/EntityData")]
public class D_Entity : ScriptableObject
{
    public float wallCheckDis = 0.2f;
    public float ledgeCheckDis = 0.4f;
    public float groundCheckRadius = 0.2f;
    public float playerAggroMinRange = 3;
    public float playerAggroMaxRange = 4;
    public float stunAnit = 3f; //受多少attackStun次后眩晕
    public float attackCloseCheckDis;

    public float health;
    
    public LayerMask player;
    public LayerMask ground;
}
