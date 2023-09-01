using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AggresiveData", menuName = "Data/Weapon Data/AggresiveWeaponData")]
public class AggresiveWeaponData : WeaponData
{
    [SerializeField] public WeaponAttackDetails[] weaponAttackDetails;
    private void OnEnable() {
        attackCount = weaponAttackDetails.Length;
        attackMoveSpeed = new float[attackCount];
        for(int i=0; i <attackCount; ++i)
        {
            attackMoveSpeed[i] = weaponAttackDetails[i].attackMoveSpeed;

        }
    }   
}
