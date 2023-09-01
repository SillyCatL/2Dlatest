using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHitToWeapons : MonoBehaviour
{
    AggresiveWeapon weapon;
    private void Awake() {
        weapon = transform.GetComponentInParent<AggresiveWeapon>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        weapon.AddToCollision(other);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        weapon.RemoveCollisin(other);
    }
}
