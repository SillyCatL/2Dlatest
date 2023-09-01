using System.Numerics;
using UnityEngine;

[System.Serializable ]
public struct WeaponAttackDetails
{
    public string attackName;
    public float attackDamage;
    public float attackMoveSpeed;

    public float knockStrength;
    public UnityEngine.Vector2 knockAngle;
}