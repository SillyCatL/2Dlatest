using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StunData", menuName = "Data/Enemy Date/StunData")]
public class D_Stun : ScriptableObject
{
    public float stunTime = 2f;
    public float knockBackTime = 0.3f;
    public Vector2 stunDir;
    public float stunSpeed;
}
