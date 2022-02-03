using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2SeaweedController : MonoBehaviour
{
    public Sprite DestroedSprite;
    public List<GameObject> upperSeaweed;
    public GameObject door;
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
            foreach(GameObject seaweed in upperSeaweed)
            {
                seaweed.SetActive(false);
            }
            door.transform.position = new Vector3(door.transform.position.x, door.transform.position.y-2.5f, door.transform.position.z);
        }
    }
}
