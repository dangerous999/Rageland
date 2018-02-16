using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float maxSpeed = 10f;
    public float acceleration = 35f;
    public float jumpSpeed = 8f;
    public float JumpDuration;

    public bool EnableDoubleJump = true;
    public bool wallHitDoubleJumpOverride = true;

    bool canDoubleJump = true;

    float jumpDuration;

    bool jumpKeyDown = false;
    bool canVariableJump = false;

    private Rigidbody2D rb2D;
    void Start()
    {
        rb2D = this.GetComponent<Rigidbody2D>();
    }

	// Update is called once per frame
	void Update ()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal < -0.1f)
        {
            if (rb2D.velocity.x > -this.maxSpeed)
            {
                rb2D.AddForce(new Vector2(-this.acceleration, 0.0f));
            }
            else
            {
                rb2D.velocity = new Vector2(-this.maxSpeed, rb2D.velocity.y);
            }
        }
        else if (horizontal > 0.1f)
        {
            if (rb2D.velocity.x < this.maxSpeed)
            {
                rb2D.AddForce(new Vector2(this.acceleration, 0.0f));
            }
            else
            {
                rb2D.velocity = new Vector2(this.maxSpeed, rb2D.velocity.y);
            }
        }



        bool onTheGround = isOnGround();

        float vertical = Input.GetAxis("Vertical");

        if (onTheGround)
        {
            canDoubleJump = true;
        }
        if (vertical > 0.1f)
        {
            if (!jumpKeyDown)
            {
                jumpKeyDown = true;
                if (onTheGround || (canDoubleJump && EnableDoubleJump) || wallHitDoubleJumpOverride)
                {
                    bool wallHit = false;
                    int wallHitDirection = 0;

                    bool leftWallHit = isOnWallLeft();
                    bool rightWallHit = isOnWallRight();

                    if (horizontal != 0)
                    {
                        if (leftWallHit)
                        {
                            wallHit = true;
                            wallHitDirection = 1;
                        }
                        else if(rightWallHit)
                        {
                            wallHit = true;
                            wallHitDirection = -1;
                        }
                    }

                    if (!wallHit)
                    {
                        if (onTheGround || (canDoubleJump && EnableDoubleJump))
                        {
                            rb2D.velocity = new Vector2(rb2D.velocity.x, this.jumpSpeed);
                            jumpDuration = 0.0f;
                            canVariableJump = true;
                        }
                    }
                    else
                    {
                        rb2D.velocity = new Vector2(this.jumpSpeed * wallHitDirection, this.jumpSpeed);

                        jumpDuration = 0.0f;
                        canVariableJump = true;
                    }

                    if (!onTheGround && !wallHit)
                    {
                        canDoubleJump = false;
                    }
                }
            }// 2nd frame
            else if(canVariableJump)
            {
                jumpDuration += Time.deltaTime;
                if (jumpDuration < this.JumpDuration / 1000)
                {
                    rb2D.velocity = new Vector2(rb2D.velocity.x, this.jumpSpeed);
                }
            }
        }
        else
        {
            jumpKeyDown = false;
            canVariableJump = false;
        }
	}

    private bool isOnGround()
    {
        float lengthToSearch = 0.1f;
        float colliderThreshold = 0.001f;

        Vector2 linestart = new Vector2(this.transform.position.x, 
                                        this.transform.position.y - this.GetComponent<Renderer>().bounds.extents.y - colliderThreshold);
        Vector2 vectorToSearch = new Vector2(this.transform.position.x, linestart.y - lengthToSearch);
        RaycastHit2D hit = Physics2D.Linecast(linestart, vectorToSearch);
        return hit;
    }
    private bool isOnWallLeft()
    {
        bool retVal = false;
        float lengthToSearch = 0.1f;
        float colliderThreshold = 0.01f;
        Vector2 linestart = new Vector2(this.transform.position.x - this.GetComponent<Renderer>().bounds.extents.x - colliderThreshold,
                                        this.transform.position.y);
        Vector2 vectorToSearch = new Vector2(linestart.x - lengthToSearch, this.transform.position.y);
        RaycastHit2D hitLeft = Physics2D.Linecast(linestart, vectorToSearch);
        retVal = hitLeft;

//        if (hitLeft.collider.GetComponent<GameObject>().CompareTag("Ground"))

        return retVal;
    }

    private bool isOnWallRight()
    {
        bool retVal = false;
        float lengthToSearch = 0.1f;
        float colliderThreshold = 0.01f;
        Vector2 linestart = new Vector2(this.transform.position.x + this.GetComponent<Renderer>().bounds.extents.x - colliderThreshold,
                                        this.transform.position.y);
        Vector2 vectorToSearch = new Vector2(linestart.x + lengthToSearch, this.transform.position.y);
        RaycastHit2D hitRight = Physics2D.Linecast(linestart, vectorToSearch);
        retVal = hitRight;

        return retVal;
    }
}
