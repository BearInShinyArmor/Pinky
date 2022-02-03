using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperController : MonoBehaviour
{
    public float movementSpeed = 1;
    public Rigidbody2D regidbody;
    public float jumpForce = 20f;
    public Animator animator;

    public GameObject Human;
    public GameObject DummyTailStrike;
    public float rotationSpeed = 30f;

    float mx; 
    float my;
    bool tailAnimationInProgress = false;
    float rotationAngle = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mx = Input.GetAxisRaw("Horizontal");
        my = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Jump"))
        {
            TailStrike();
        }
        if (tailAnimationInProgress)
        {
            TailStrikeAnimation();
        }
    }

    private void TailStrikeAnimation()
    {
        rotationAngle -= Time.deltaTime*rotationSpeed;
        if (rotationAngle < 0) { rotationAngle = 0; }
        gameObject.transform.eulerAngles = new Vector3(0, 0, rotationAngle);
        if (rotationAngle == 0) { tailAnimationInProgress = false; }

    }

    private void TailStrike()
    {
        DummyTailStrike.transform.position = new Vector3(gameObject.transform.position.x + 0.6f * (gameObject.GetComponent<SpriteRenderer>().flipX == true ? -1 : 1), gameObject.transform.position.y, gameObject.transform.position.z);
        DummyTailStrike.SetActive(true);
        DummyTailStrike.GetComponent<DummyTailStrikeController>().Activate();
        StartTailAnimation();
    }

    private void StartTailAnimation()
    {
        tailAnimationInProgress = true;
        rotationAngle = 360;
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(mx * movementSpeed, my * movementSpeed);
        regidbody.velocity = movement;
        animator.SetFloat("Speed", Math.Abs(movement.x)+Math.Abs(movement.y));
        if (mx > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX=false;
        }
        else
        {
            if (mx < 0)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Water")
        {
           Jump();
            Invoke("TransformToHuman", 0.5f);
        }
    }
    private void Jump()
    {
        
        regidbody.gravityScale = -17f;
    }
    private void TransformToHuman()
    {
        Human.SetActive(true);
        Human.transform.position = gameObject.transform.position;
        Human.GetComponent<Rigidbody2D>().velocity = regidbody.velocity;
        regidbody.gravityScale = 0;
        gameObject.SetActive(false);
    }
}

