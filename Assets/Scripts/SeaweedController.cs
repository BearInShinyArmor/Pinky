using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaweedController : MonoBehaviour
{
    public Sprite DestroedSprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.tag == "DummyTailStrike")
        {
            
            gameObject.GetComponent<SpriteRenderer>().sprite = DestroedSprite;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
