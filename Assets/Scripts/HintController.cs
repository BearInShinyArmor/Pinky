using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintController : MonoBehaviour
{
    float TimeToLive=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimeToLive -= Time.deltaTime;
        if (TimeToLive <= 0)
        {
            gameObject.SetActive(false);
        }
        
    }

    internal void Refresh()
    {
        TimeToLive = 4;
    }

    internal void SetLeverHint()
    {
        gameObject.GetComponentInChildren<Text>().text = "Press E to pull the lever";
    }
    internal void SetTailAttackHint()
    {
        gameObject.GetComponentInChildren<Text>().text = "Press Space to smash the obstacle";
    }
}
