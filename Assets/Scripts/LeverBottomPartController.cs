using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverBottomPartController : MonoBehaviour
{
    public GameObject LeverPartIcon;
    public GameObject Lever;
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
        if (collision.gameObject.tag =="Player")
        {
            
            
            if (LeverPartIcon.activeSelf)
            {
               
                LeverPartIcon.SetActive(false);
                Lever.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }
}
