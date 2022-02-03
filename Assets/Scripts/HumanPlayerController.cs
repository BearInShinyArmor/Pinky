using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanPlayerController : MonoBehaviour
{
    public float movementSpeed = 1;
    public Rigidbody2D regidbody;
    public float jumpForce = 10f;
    public Transform feet;
    public LayerMask groundLayers;

    public GameObject Flipper;

    public GameObject CollidedLever;
    public Animator animator;

    float mx;
    bool falling = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mx = Input.GetAxisRaw("Horizontal");
        if (Input.GetButton("Jump")&& IsGrounded())
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.E) && CollidedLever!=null)
        {
            CollidedLever.GetComponent<LeverController>().PullLever();
        }
        
    }

    private bool IsGrounded()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.25f, groundLayers);
        if(groundCheck != null)
        {
            return true;
        }
        return false;
    }

    private void Jump()
    {

        Vector2 movement = new Vector2( regidbody.velocity.x, jumpForce);
        regidbody.velocity = movement;
        animator.SetBool("IsGrounded", false);
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(mx * movementSpeed, regidbody.velocity.y);
        regidbody.velocity = movement;
        if (mx > 0) { gameObject.GetComponent<SpriteRenderer>().flipX = false; }
        else { if (mx < 0) { gameObject.GetComponent<SpriteRenderer>().flipX = true; } }
        animator.SetFloat("Speed", Math.Abs(movement.x));
        if (regidbody.velocity.y < 0) { falling = true; }
        if (regidbody.velocity.y == 0 && falling) { animator.SetBool("IsGrounded", true); falling = false; }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            Invoke("TransformToFlipper", 0.28f);
        }
        if (collision.gameObject.tag == "Lever")
        {
            CollidedLever = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Lever")
        {
            CollidedLever = null;
        }
    }

    private void TransformToFlipper()
    {
        Flipper.SetActive(true);
        Flipper.transform.position = gameObject.transform.position;
        Flipper.GetComponent<Rigidbody2D>().velocity = regidbody.velocity;
        gameObject.SetActive(false);
    }

    
}
