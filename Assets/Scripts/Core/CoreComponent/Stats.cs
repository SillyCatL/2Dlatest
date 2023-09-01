using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : CoreComponent
{
    [SerializeField]
    private float healthMax;
    private float currentHealth;

    protected override void Awake()
    {
        currentHealth = healthMax;
    }

    public void DecreseHealth(float count)
    {
        currentHealth -= count;

        if (currentHealth <= 0)
        {
            core.death.isDeath = true;
            EventCenter.Broadcast(EventDefine.death);
        }
    }

    public void AddHealth(float count)
    {
        //Mathf.Clamp 将一个数限定在某个范围内
        currentHealth += Mathf.Clamp(currentHealth + count, 0, healthMax);
    }
}
