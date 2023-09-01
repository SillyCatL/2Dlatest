using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : CoreComponent
{
    [SerializeField]
    private GameObject[] deathParticle;

    public bool isDeath;

    private void Start()
    {
        isDeath = false;
    }

    public void Die()
    {
        foreach (GameObject g in deathParticle)
        {
            core.particle.StartParticles(g);
        }

        core.transform.parent.gameObject.SetActive(false);
    }

    protected override void Update()
    {
        if (isDeath == true)
        {
            EventCenter.AddListener(EventDefine.death, Die);
            isDeath = false;
        }

    }

    private void OnDisable()
    {
        EventCenter.RemoveListener(EventDefine.death, Die);
    }

}
