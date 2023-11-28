using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMovement1 : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float jetpackForce = 3f;
    [SerializeField] private float maxFlightTime = 5f;
    private float currentFlightTime;
    private float moveInput;
    private bool isFlying = false;
    private bool isGrounded = false;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        currentFlightTime = maxFlightTime;
    }

    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
        isFlying = Input.GetButton("Fire1");
        if (isFlying && currentFlightTime > 0)
        {
            currentFlightTime -= Time.deltaTime;
            Debug.Log(currentFlightTime);
        }
    }

    private void FixedUpdate()
    {
        if (isFlying && currentFlightTime > 0)
        {
            rb.AddForce(Vector2.up * jetpackForce);
        }

        if (isGrounded == false)
        {
            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
            if (moveInput > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0); // Menghadap ke kanan
            }
            else if (moveInput < 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0); // Menghadap ke kiri
            }
        }
        else
        {
            if (currentFlightTime < maxFlightTime)
            {
                currentFlightTime += Time.deltaTime;
            }
            Debug.Log(currentFlightTime);
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }
    private void OnCollisionEnter2D(Collision2D col) 
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            
            Debug.Log(isGrounded);
        }
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            Debug.Log(isGrounded);
        }
    }
}

