using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesController : MonoBehaviour
{
    public float amplitude = 1;
    public float speed = 0.1f;
    float deviation = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector2(gameObject.transform.position.x + speed, gameObject.transform.position.y);
        deviation = deviation + speed;
        if(Mathf.Abs(deviation) > amplitude)
        {
            speed = -speed;
        }
        
    }
}
