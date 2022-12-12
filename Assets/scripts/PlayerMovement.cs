using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Speed of the player's movement
    public float speed = 5;

    // Force applied to the player when jumping
    public float jumpForce = 10;
    private bool isJumping = false;

    // Reference to the player's rigidbody component
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get input from the user
        float horizontalInput = Input.GetAxis("Horizontal");
        bool jumpInput = Input.GetButtonDown("Jump");
        anim.SetBool("isRunning", horizontalInput != 0);

        // Flip the sprite horizontally if the player is moving in the opposite direction
        if (horizontalInput < 0 && !spriteRenderer.flipX || horizontalInput > 0 && spriteRenderer.flipX)
            spriteRenderer.flipX = !spriteRenderer.flipX;

        // Move the player in the horizontal direction
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        // If the user presses the jump button, apply a force to the player
        anim.SetBool("isGrounded", IsGrounded());
        if (jumpInput && IsGrounded() && !isJumping)
        {
            isJumping = true;
            anim.SetTrigger("jump");
        }

        CheckSpecialMovements();
    }

    // Returns true if the player is on the ground, false otherwise
    bool IsGrounded()
    {
        // Cast a ray downward from the center of the player's collider
        RaycastHit2D hit = Physics2D.Raycast(
            GetComponent<Collider2D>().bounds.center,
            Vector2.down,
            GetComponent<Collider2D>().bounds.extents.y + 0.1f,
            LayerMask.GetMask("Ground")
        );

        // If the ray hits something, the player is grounded
        return hit.collider != null;
    }

    public void StartJumpEvent()
    {
        isJumping = false;
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    public void CheckSpecialMovements()
    {
        if (Input.GetKeyDown(KeyCode.E))
            anim.SetTrigger("transform");
        
        if (Input.GetKeyDown(KeyCode.F))
            anim.SetTrigger("pick");

        if (Input.GetMouseButtonDown(0))
            anim.SetTrigger("aim");
        
        if (Input.GetMouseButtonUp(0))
            anim.SetTrigger("attack");

    }
}