using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAfterImage : MonoBehaviour
{
    [Header("闪烁存活时间")]
    [SerializeField]
    private float activeTimeSet = 0.1f;
    private float activeTime;
    private float alpha;
    private float alphaSet = 0.8f;
    private float alphMultiplier = 0.85f;


    private Transform playerTrans;
    private SpriteRenderer sp;
    private SpriteRenderer playerSp;
    private Color color;

    private void OnEnable()
    {

        sp = GetComponent<SpriteRenderer>();
        playerTrans = GameObject.Find("Player").GetComponent<Transform>();
        playerSp = GameObject.Find("Player").GetComponent<SpriteRenderer>();

        transform.SetPositionAndRotation(playerTrans.position, playerTrans.rotation);
        alpha = alphaSet;
        sp.sprite = playerSp.sprite;
        activeTime = 0;
    }

    private void Update()
    {
        alpha *= alphMultiplier;
        color = new Color(1,1,1,alpha);
        sp.color = color;
        activeTime += Time.deltaTime;
        if (activeTime >= activeTimeSet)
        {
            ImageObjectPool.Instance.AddToPool(gameObject);
        }
    }
}
