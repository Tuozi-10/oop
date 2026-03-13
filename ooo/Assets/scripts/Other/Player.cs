using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CubeMovement2D : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 7f;
    public float jumpForce = 10f;
    public float raycastDistance = 0.6f;
    public LayerMask groundLayer;  

    private Rigidbody2D rb;
    private float horizontalInput;
    private bool isGrounded;
    private Vector2 slopeNormalPerp;
    private bool isOnSlope;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        CheckGround();

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        ApplyMovement();
    }

    void CheckGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, raycastDistance, groundLayer);

        if (hit)
        {
            isGrounded = true;
            slopeNormalPerp = Vector2.Perpendicular(hit.normal).normalized;
            isOnSlope = hit.normal != Vector2.up;
        }
        else
        {
            isGrounded = false;
            isOnSlope = false;
        }
    }
    
    private bool isJumping;

    void Jump()
    {
        isJumping = true;
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0); // Reset Y
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    
        Invoke(nameof(ResetJumpingFlag), 0.1f); 
    }

    void ResetJumpingFlag() => isJumping = false;

    void ApplyMovement()
    {
        if (isGrounded && isOnSlope && !isJumping)
        {
            rb.linearVelocity = new Vector2(speed * slopeNormalPerp.x * -horizontalInput, speed * slopeNormalPerp.y * -horizontalInput);
        }
        else
        {
            rb.linearVelocity = new Vector2(horizontalInput * speed, rb.linearVelocity.y);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = isGrounded ? Color.green : Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * raycastDistance);
    }
}