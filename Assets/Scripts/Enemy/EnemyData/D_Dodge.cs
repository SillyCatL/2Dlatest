using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dodge", menuName = "Data/Enemy Date/Dodge")]
public class D_Dodge : ScriptableObject
{
    public float dodgeSpeed = 15f;
    public float dodgeTime = 0.2f;
    public float dodgeCoolTime = 2f;
    public Vector2 dodgeAngle;
}
