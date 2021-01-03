using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float moveSpeed;
    public float jumpMoveSpeed;
    private float speed;
    public float jumpHeight;
    public bool isFacingRight;
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

    //Shooting basic fireball
    public Transform  shootingPoint;
    public GameObject basicFireball;
    public KeyCode basicFireballKey;

    //Shooting super fireball
    public GameObject superFireball;
    public KeyCode superFireballKey;

    private PlayerStats playerStats;


    // Use this for initialization
    void Start ()
    {
        playerStats = this.GetComponent<PlayerStats>();


        isFacingRight = true;
        anim = GetComponent<Animator>();

        playerStats.BasicFireBallTimer = 0f;
        playerStats.isbasicFireBallOnCooldown = false;

        playerStats.SuperFireBallTimer = 0f;
        playerStats.isSuperFireBallOnCooldown = false;

        playerStats.DashTimer = 0f;
        playerStats.isDashOnCooldown = false;

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
    public void shootBasicFireBall()
    {
        Instantiate(basicFireball, shootingPoint.position, shootingPoint.rotation);
        playerStats.isbasicFireBallOnCooldown = true;
    }

    public void shootSuperFireball()
    {
        Instantiate(superFireball, shootingPoint.position, shootingPoint.rotation);
        playerStats.isSuperFireBallOnCooldown = true;
    }
    // Update is called once per frame
    void Update () {
        //shooting basic fireball
        if (Input.GetKeyDown(basicFireballKey) && !playerStats.isbasicFireBallOnCooldown)
        {
            shootBasicFireBall();
        }     
        //start cooldown timer for basic fireball
        if (playerStats.isbasicFireBallOnCooldown)
        {
            playerStats.BasicFireBallTimer += Time.deltaTime;
            if(playerStats.BasicFireBallTimer >= playerStats.basicFireBallCooldown)
            {
                playerStats.isbasicFireBallOnCooldown = false;
                playerStats.BasicFireBallTimer = 0;
            }
        }

        //shooting super fireball
        if (Input.GetKeyDown(superFireballKey) && !playerStats.isSuperFireBallOnCooldown)
        {
            shootSuperFireball();
        }
        if (playerStats.isSuperFireBallOnCooldown)
        {
            playerStats.SuperFireBallTimer += Time.deltaTime;
            if (playerStats.SuperFireBallTimer >= playerStats.superFireBallCooldown)
            {
                playerStats.isSuperFireBallOnCooldown = false;
                playerStats.SuperFireBallTimer = 0;
            }
        }

        if (Input.GetKey(Teleport) && !isTeleporting)
        {
            if (!playerStats.isDashOnCooldown)
            {
                isTeleporting = true;
                playerStats.isDashOnCooldown = true;
            }
        }
        if (playerStats.isDashOnCooldown)
        {
            playerStats.DashTimer += Time.deltaTime;
            if (playerStats.DashTimer >= playerStats.dashCooldown)
            {
                playerStats.isDashOnCooldown = false;
                playerStats.DashTimer = 0f;
            }
        }
        //start cooldown timer for super fireball

        if (isTeleporting) {
            teleportTime += Time.deltaTime;
            if (teleportTime >= teleportDuration) {
                float new_x;
                isTeleporting = false;
                if (isFacingRight) 
                {
                    new_x = this.transform.position.x + transportDistance;
                }
                else 
                {
                    new_x = this.transform.position.x - transportDistance;
                }
                if (new_x > LevelManager.rightLevelBoundary) new_x = LevelManager.rightLevelBoundary;
                if (new_x < LevelManager.leftLevelBoundary) new_x = LevelManager.leftLevelBoundary;

                this.transform.position = new Vector3(new_x, this.transform.position.y, this.transform.position.z);
                teleportTime = 0;
                }
        }
        anim.SetBool("isTeleporting", isTeleporting);


		if(Input.GetKeyDown(Spacebar) && grounded)
        {
            Jump();
        }
        anim.SetBool("Grounded", grounded);

        if (!grounded) {
            speed = jumpMoveSpeed;
        }
        else {
            speed = moveSpeed;
        }

        if (Input.GetKey(L))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, GetComponent<Rigidbody2D>().velocity.y);
            if (isFacingRight)
            {
                flip();
                isFacingRight = false;
            }   
        }

        if(Input.GetKey(R))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);

            if (!isFacingRight)
            {
                flip();
                isFacingRight = true;
            }
        }

        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));

	}
}
