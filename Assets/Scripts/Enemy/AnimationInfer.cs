using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationInfer : MonoBehaviour
{
    public AttackState attackState;
    
    public void TriggerAttack()
    {
        attackState.TriggerAttack();
    }

    public void FinishAttack()
    {
        attackState.FinishAttack();
    }
}
