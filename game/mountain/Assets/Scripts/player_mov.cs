using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    [SerializeField]
    private Transform wallCheck;
   
    public float groundCheckRadius = 0.2f;
    public float jumps = 1;
    [SerializeField]
    private SpriteRenderer sr;
    public float featherboost = 1;

    private Rigidbody2D rb;
    private bool isGrounded;
    private float moveInput;
    private bool canWalljump;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void jumpmin()
    {
        jumps -= 1;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            sr.flipX = false;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            sr.flipX = true;
        }
        // Handle horizontal movement
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Check if player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        canWalljump = Physics2D.OverlapCircle(wallCheck.position, 0.2f, groundLayer);
        if (isGrounded)
        {
            jumps = 1;
            featherboost = 1;
        }

        // Handle jumping
        if (jumps > 0 && Input.GetKeyDown(KeyCode.W))
        {

            rb.AddForce(transform.up * jumpForce * featherboost, ForceMode2D.Impulse);
            Invoke("jumpmin", 0.2f);

        }
        else if (!isGrounded && canWalljump && Input.GetKeyDown(KeyCode.W)) 
        {
            rb.AddForce(transform.up * jumpForce * featherboost, ForceMode2D.Impulse);
            
        }
    }

  
}