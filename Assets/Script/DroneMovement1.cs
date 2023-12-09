using UnityEngine;

public class DroneMovement1 : MonoBehaviour
{
    [Header("Movement Parameters")]
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float jetpackForce = 3f;
    [SerializeField] private float maxFlightTime = 5f;
    [SerializeField] private float ascentMultiplier = 2f;

    private Rigidbody2D rb;
    private float currentFlightTime;
    private bool isFlying = false;
    private bool isGrounded = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        currentFlightTime = maxFlightTime;
    }

    private void Update() {
        if (isGrounded)
        {
            if (currentFlightTime < maxFlightTime)
            {
                currentFlightTime += Time.deltaTime;
            }
        }
    }

    private void FixedUpdate()
    {
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            return;
        }
        HandleHorizontalMovement();
        HandleFlying();
    }

    private void HandleHorizontalMovement()
    {
        Vector2 moveDirection = InputManager.GetInstance().GetMoveDirection();
        if (isGrounded == false)
        {
            rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);
            if (moveDirection.x > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (moveDirection.x < 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
        else
        {
            if (currentFlightTime < maxFlightTime)
            {
                currentFlightTime += Time.deltaTime;
            }
            Debug.Log(currentFlightTime);
            // rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    private void HandleFlying()
    {
        float jetpackInput = InputManager.GetInstance().GetJetpackInput();
        isFlying = jetpackInput > 0 && currentFlightTime > 0;

        if (isFlying)
        {
            isGrounded = false;
            rb.AddForce(Vector2.up * jetpackForce * ascentMultiplier);

            currentFlightTime -= Time.deltaTime;
            Debug.Log(currentFlightTime);
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
