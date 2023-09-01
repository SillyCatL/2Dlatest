using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : CoreComponent
{
    GameObject particleManager;

    protected override void Awake()
    {
        particleManager = GameObject.FindWithTag("ParticleManager");
    }

    public GameObject StartParticles(GameObject prefab, Vector2 positon, Quaternion rotation)
    {

        return Instantiate(prefab, positon, rotation, particleManager.transform);
    }
    public GameObject StartParticles(GameObject prefab)
    {
        return StartParticles(prefab, core.movement.rb.transform.position, Quaternion.identity);   
    }

    public GameObject StartParticlesWithRandowmRotation(GameObject prefab, Vector2 positon)
    {
        var randomPos = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
        return StartParticles(prefab, positon, randomPos);
    }
}
