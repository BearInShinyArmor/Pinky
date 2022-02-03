using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour
{
    public GameObject hint;
    public GameObject Door;
    public Sprite LeverPulled;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            hint.SetActive(true);
            hint.GetComponent<HintController>().Refresh();
            hint.GetComponent<HintController>().SetLeverHint();
        }
    }

    internal void PullLever()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = LeverPulled;
        Door.GetComponent<DoorController>().OpenDoor();
    }
}
