using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    public Movement movement { get; private set; }
    public CollisionSense collisionSense { get; private set; }
    public Combated combated{ get; private set; }
    public Stats stats{ get; private set; }
    public Particle particle { get; private set; }
    public Death death { get; private set; }

    private void Awake()
    {
        stats = GetComponentInChildren<Stats>();
        movement = GetComponentInChildren<Movement>();
        collisionSense = GetComponentInChildren<CollisionSense>();
        combated = GetComponentInChildren<Combated>();
        particle = GetComponentInChildren<Particle>();
        death = GetComponentInChildren<Death>();
    }

    private void Update()
    {

    }
    

}
