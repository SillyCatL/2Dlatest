using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "LongAttack", menuName = "Data/Enemy Date/LongAttack")]
public class D_LongAttack : ScriptableObject
{
    public GameObject projectile;
    public float projectileDamage = 10f;
    public float projectileSpeed = 12f;
    public float projectileDis;
}
