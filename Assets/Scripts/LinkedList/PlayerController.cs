using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    public SpriteRenderer sprite;

    public float moveSpeed;
    public float moveVelocity;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public bool grounded;
    public float jumpHeight;
    private float jumpTimeCounter;
    public float jumpTime;


    private bool jump;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moveVelocity = 0f;

        if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }

        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }

        if (rb.velocity.x > 0)
        {
            sprite.flipX = false;
        }

        if (rb.velocity.x < 0)
        {
            sprite.flipX = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && grounded) // Jumping
        {
            jump = true;
            print("jump");
        }

    }

    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        if (jump)
        {
            print("fixed jump");
            Jump();
        }
    }

    public void MoveRight()
    {
        rb.velocity = new Vector2(moveSpeed, rb.GetComponent<Rigidbody2D>().velocity.y);
        moveVelocity = moveSpeed;
    }

    public void MoveLeft()
    {
        rb.velocity = new Vector2(-moveSpeed, rb.GetComponent<Rigidbody2D>().velocity.y);
        moveVelocity = -moveSpeed;
    }

    public void Jump()
    {
        print("add force");
        rb.AddForce(Vector2.up * jumpHeight);
        jump = false;
    }
}
