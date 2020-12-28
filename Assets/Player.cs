using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float moveSpeed;
    public float jumpHeight;
    bool isFacingRight;
    bool isTeleporting = false;
    public float teleportDuration;
    float teleportTime = 0f;
    public float transportDistance;
    public KeyCode Spacebar;
    public KeyCode L;
    public KeyCode R;
    public KeyCode Teleport;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;
    private Animator anim;

    // Use this for initialization
    void Start () {
        isFacingRight = true;
        anim = GetComponent<Animator>();

		
	}

    void flip()
    {
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(Teleport) && !isTeleporting) {
            isTeleporting = true;
        }

        if (isTeleporting) {
            teleportTime += Time.deltaTime;
            if (teleportTime >= teleportDuration) {
                //COOLDOWN //TODOOOOO
                isTeleporting = false;
                this.transform.position = isFacingRight ? new Vector3(this.transform.position.x + transportDistance, this.transform.position.y, this.transform.position.z) : new Vector3(this.transform.position.x - transportDistance, this.transform.position.y, this.transform.position.z);
                teleportTime = 0;
            }
        }
        anim.SetBool("isTeleporting", isTeleporting);


		if(Input.GetKeyDown(Spacebar) && grounded)
        {
            Jump();
        }
        anim.SetBool("Grounded", grounded);

        if (Input.GetKey(L))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            if (isFacingRight)
            {
                flip();
                isFacingRight = false;
            }   
        }

        if(Input.GetKey(R))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

            if (!isFacingRight)
            {
                flip();
                isFacingRight = true;
            }
        }

        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));

	}
}
