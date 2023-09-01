using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "IdleData", menuName = "Data/Enemy Date/IdleData")]
public class D_IdleState : ScriptableObject
{
    public float minIdleTime = 1f;
    public float maxIdleTime = 2f;
}
