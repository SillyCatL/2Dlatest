using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class WeaponToWeapons : MonoBehaviour
{
    private Weapon weapon;

    private void Awake() {
        weapon = GetComponentInParent<Weapon>();
    }

    public void AnimationFinish()
    {
        weapon.AnimationFinish();
    }
    public void AnimationMoveSpeedTrigger()
    {
        weapon.AnimationMoveSpeedTrigger();
    }
    public void AnimationMoveStopTrigger()
    {
        weapon.AnimationMoveStopTrigger();
    }
    public void AnimationFlipOnTrigger()
    {
        weapon.AnimationFlipOnTrigger();
    }
    public void AnimationFlipOffTrigger()
    {
        weapon.AnimationFlipOffTrigger();
    }
    public void AnimationActionTrriger()
    {   
        weapon.AnimationActionTrriger();
    }
}
