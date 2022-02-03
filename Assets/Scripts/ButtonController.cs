using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public Sprite ButtonPressed;
    public GameObject Door;
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
      
        gameObject.GetComponentInParent<SpriteRenderer>().sprite = ButtonPressed;
        Door.GetComponent<DoorController>().OpenDoor();
    }
}
