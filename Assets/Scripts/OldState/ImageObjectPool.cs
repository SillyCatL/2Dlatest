using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageObjectPool : MonoBehaviour
{
    public GameObject ImagePrefab;
    private Queue<GameObject> imageObjectPool = new();
    public static ImageObjectPool Instance;
    private void Start()
    {
        Instance = this;
        GrowPool();
    }

    private void GrowPool()
    {
        for (int i = 0; i < 10; ++i)
        {
            var gam = Instantiate(ImagePrefab);
            gam.transform.SetParent (transform);
            AddToPool(gam);
        }
    }

    public void AddToPool(GameObject gameObject)
    {
        imageObjectPool.Enqueue(gameObject);
        gameObject.SetActive(false);
    }

    public GameObject GetFromPool()
    {
        if(imageObjectPool.Count == 0)
        {
            GrowPool();
        }
        var gm = imageObjectPool.Dequeue();
        gm.SetActive(true);
        return gm;
    }
}
