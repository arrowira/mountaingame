using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerMovement : MonoBehaviour
{
    public bool moveEnable = true;
    public float moveSpeed = 5f;
    [SerializeField]
    private float onGroundMoveSpeed = 5f;
    [SerializeField]
    private float offGroundMoveSpeed = 3f;
    public float jumpForce = 10f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    [SerializeField]
    private Transform wallCheck;
    [SerializeField]
    private float pushoffset = 30;
    private float pushoff = 0f;
    public float groundCheckRadius = 0.2f;
    public float jumps = 1;
    [SerializeField]
    private SpriteRenderer sr;
    public float featherboost = 1;
    [SerializeField]
    private Rigidbody2D rb;
    private bool isGrounded;
    private float moveInput;
    private bool canWalljump;
    
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
    }
    private void jumpmin()
    {
        jumps -= 1;
    }
    private void enablemovement()
    {
        moveEnable = true;
    }
    public void resetVel()
    {
        rb.velocity= Vector3.zero;
    }
    private void FixedUpdate()
    {
        if (pushoff != 0)
        {
            pushoff += 1;
        }
    }
    void Update()
    {
        //Physics2D.gravity = new Vector2(0, -20f);
        if (isGrounded)
        {
            moveSpeed = onGroundMoveSpeed;
        }
        else
        {
            moveSpeed = offGroundMoveSpeed;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            //0.68
            wallCheck.localPosition = new Vector3(0.68f, 0, 0);
            sr.flipX = false;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            //-0.75
            wallCheck.localPosition = new Vector3(-0.75f, 0, 0);
            sr.flipX = true;
        }
        // Handle horizontal movement
        moveInput = Input.GetAxis("Horizontal");
        if (moveEnable == true)
        {
            rb.AddForce(((moveSpeed * moveInput) - rb.velocity.x) * transform.right, ForceMode2D.Force);
        }


        //rb.velocity = new Vector2((moveInput * moveSpeed) + pushoff, rb.velocity.y);

        // Check if player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        canWalljump = Physics2D.OverlapCircle(wallCheck.position, 0.5f, groundLayer);
        if (isGrounded)
        {
            jumps = 1;
            featherboost = 1;
        }
        if (canWalljump)
        {
            featherboost = 1;
        }
        // Handle jumping
        if (jumps > 0 && Input.GetKeyDown(KeyCode.W))
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(transform.up * jumpForce * featherboost, ForceMode2D.Impulse);
            Invoke("jumpmin", 0.2f);

        }
        else if (!isGrounded && canWalljump && Input.GetKeyDown(KeyCode.W))
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(transform.up * jumpForce * featherboost, ForceMode2D.Impulse);
            if (sr.flipX == false)
            {
                rb.AddForce(-transform.right * pushoffset, ForceMode2D.Impulse);
            }
            else
            {
                rb.AddForce(transform.right * pushoffset, ForceMode2D.Impulse);
            }

            moveEnable = false;
            Invoke("enablemovement", 1f);
        }
    }
}