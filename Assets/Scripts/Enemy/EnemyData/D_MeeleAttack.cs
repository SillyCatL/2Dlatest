using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MeeleAttack", menuName = "Data/Enemy Date/MeeleAttack")]
public class D_MeeleAttack : ScriptableObject
{
    public float attackDamage;
    public float knockStrength;
    public UnityEngine.Vector2 knockAngle;

    public float attackRadius;

    public LayerMask player;
}
