using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyTailStrikeController : MonoBehaviour
{
    public float timeToLive = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeToLive -= Time.deltaTime;
        if (timeToLive <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    internal void Activate()
    {
        timeToLive = 0.5f;
    }
}
