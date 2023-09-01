using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Data/Weapon Data/WeaponData")]
public class WeaponData : ScriptableObject
{
    public int attackCount { get; protected set; }
    public float[] attackMoveSpeed { get; protected set; }
}
    