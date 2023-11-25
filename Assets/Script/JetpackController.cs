using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]private float moveSpeed = 3f;
    [SerializeField]private float rotationSpeed = 3f;
    private float moveInput;
    [SerializeField]private float jetpackForce = 3f;
    [SerializeField]private float boxLength;
    [SerializeField]private float boxHeight;
    [SerializeField]private LayerMask groundLayer;
    [SerializeField]private Transform groundPosition;
    private bool isFlying = false;
    private Collider2D[] isGrounded = new Collider2D[1];
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
        isFlying = Input.GetButton("Fire1");
    }

    private void FixedUpdate()
    {
        isGrounded[0] = null;
        Physics2D.OverlapBoxNonAlloc(groundPosition.position, new Vector2(boxLength, boxHeight), 0, isGrounded, groundLayer);
        
        if (isGrounded[0] || !isFlying)
        {
            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
            rb.freezeRotation = true;
        }
        else if (isFlying)
        {
            Vector3 rotation = new Vector3(0, 0, -moveInput * rotationSpeed);
            transform.Rotate(rotation);
            rb.freezeRotation = false;
        }

        if (isFlying)
        {
            rb.AddForce(Vector2.up * jetpackForce);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(groundPosition.position, new Vector2(boxLength, boxHeight));
    }
}
