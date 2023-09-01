using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreComponent : MonoBehaviour
{
    protected Core core;
    protected virtual void Awake()
    {
        core = transform.GetComponentInParent<Core>();
    }
    
    protected virtual void Update()
    {
        core = transform.GetComponentInParent<Core>();
    }
}
