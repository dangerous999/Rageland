using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public bool canDoubleJump; 
    public bool grounded = false; // See GroundCheck.cs
    public bool canWallJump = false; // See WallCheck.cs
    public bool hasJumped;
    public bool wallJumped;
    
    public float jumpPower = 410f;
    public float maxSpeed = 4.5f;

    public float wallJumpPushForce = 10f;
    public float wallJumpPower = 10f;

    public float maxFallSpeed = 10f;
    public float maxSlideSpeed = 1.5f;
    public float acceleration = 10f;

    public Transform currentSpawnPoint;

    public int jumpCount = 0;

    private Rigidbody2D rb2D;
    private Animator anim;
    private GameMaster gm;

    private float timer;

    // Use this for initialization
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentSpawnPoint = GameObject.FindGameObjectWithTag("Spawn").GetComponent<Transform>(); // Set player spawnpoint to current level spawnpoint
        transform.position = currentSpawnPoint.transform.position;
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
    }
    // Update is called once per frame
    void Update()
    {
        // Animation control
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(rb2D.velocity.x));
        anim.SetBool("CanWallJump", canWallJump);
        // Jump
        if (grounded)
        {           
            canDoubleJump = true;
            if ( hasJumped == false )
            {
                jumpCount = 0;
            }
        }

        if (Input.GetButtonDown("Jump"))
        {
            JumpManager();
        }

    }
    // Physics movement
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.A))
        {
            rb2D.velocity = new Vector2(x * maxSpeed, rb2D.velocity.y);
            transform.localScale = new Vector3(-1, 1, 1);
//            transform.Translate(new Vector2(-maxSpeed, 0) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb2D.velocity = new Vector2(x * maxSpeed, rb2D.velocity.y);
            transform.localScale = new Vector3(1, 1, 1);
           // transform.Translate(new Vector2(maxSpeed, 0) * Time.deltaTime);
        }
      //  Debug.Log(rb2D.velocity.y);
        // Wall slide speed and falling/rising speed
        if (canWallJump)
        {
            if (rb2D.velocity.y < -maxSlideSpeed)
                rb2D.velocity = new Vector2(rb2D.velocity.x, -maxSlideSpeed);
        }
        else
        {
            if (rb2D.velocity.y < -maxFallSpeed)
                rb2D.velocity = new Vector2(rb2D.velocity.x, -maxFallSpeed);
            if (rb2D.velocity.y > maxFallSpeed)
                rb2D.velocity = new Vector2(rb2D.velocity.x, maxFallSpeed);
        }

    }
    void Jump()
    {
        ++jumpCount;
        rb2D.velocity = new Vector2(rb2D.velocity.x, 0); // Set y velocity to 0 to ignore gravity
        rb2D.AddForce(Vector2.up * jumpPower);
        hasJumped = true;
    }
    void WallJump()
    {
        wallJumped = true;

        // TODO Is this line even needed?
      //  rb2D.velocity = new Vector2(rb2D.velocity.x, 0); // Make y velocity 0 to ignore gravity
        /////////////////////// WIP 
//        rb2D.velocity = new Vector2(wallJumpPushForce * -transform.localScale.x, this.jumpPower);
        /////////////////////// 
      //   rb2D.AddForce(new Vector2(wallJumpPushForce * -transform.localScale.x, jumpPower)); // Push in opposite of facing direction
        rb2D.velocity += new Vector2(wallJumpPushForce * -transform.localScale.x, wallJumpPower);
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z); // Flip sprite
        ++jumpCount;
    }
    void JumpManager()
    {       
        if (grounded /*&& !wallJumped*/) {
            hasJumped = false;
            Jump();
            canDoubleJump = true;
        }
        else if (canWallJump /*&& !wallJumped*/) { // If player is touching wall and isn't grounded
            canDoubleJump = false;                 // see WallCheck.cs
            WallJump();
        }
        else if (canDoubleJump /*&& !wallJumped*/) { // Double jump
            canDoubleJump = false;
            Jump();
        }
        else if (jumpCount <= 1 /*&& !wallJumped*/) { // Jump after falling without jumping
            canDoubleJump = false;
            Jump();
        }
    }
    public void Die()
    {
        // Set position of player to position of spawnpoint
        rb2D.velocity = new Vector2(0f, 0f); // Set player velocity to 0 
        rb2D.transform.position = currentSpawnPoint.transform.position;
        gm.deaths += 1;

    }
}
