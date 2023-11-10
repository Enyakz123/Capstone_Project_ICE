using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float jump;
    private Animator anim;
    private bool grounded = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");
    
        rb.velocity = new Vector2(HorizontalInput * speed, rb.velocity.y);

        //skrip untuk berbalik

        if(HorizontalInput > 0)
        {
            FlipCharacterRight();
        }
        else if (HorizontalInput < 0 )
        {
            FlipCharacterLeft();  
        }
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Jump();
        }

        anim.SetBool("run", HorizontalInput!=0);
        anim.SetBool("grounded", grounded);
    }

    private void FlipCharacterRight()
    {
        if (transform.localScale.x <0)
            {
                Vector3 newScale = transform.localScale;
                newScale.x *= -1;
                transform.localScale = newScale;
            }
            else
            {
                Vector3 newScale = transform.localScale;
                newScale.x *= 1;
                transform.localScale = newScale;
            }
    }

    private void FlipCharacterLeft()
    {
        if (transform.localScale.x > 0)
            {
                Vector3 newScale = transform.localScale;
                newScale.x *= -1;
                transform.localScale = newScale;
            }
            else
            {
                Vector3 newScale = transform.localScale;
                newScale.x *= 1;
                transform.localScale = newScale;
            }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jump);
        // anim.SetTrigger("jump");
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground"){
            grounded = true;
        }
    }
}
