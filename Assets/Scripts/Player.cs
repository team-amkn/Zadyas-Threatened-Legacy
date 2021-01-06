using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    private bool isWallCollision;
    private GameObject dashCooldownGUI, superFireballCooldownGUI;
    private TextMeshProUGUI dashCooldownText, superFireballCooldownText;
    public bool IsWallCollision { get => isWallCollision; set => isWallCollision = value; }

    private GameObject[] heartsGUI;
    private SpriteRenderer[] heartsSprites;
    public SpriteRenderer[] HeartsSprites { get => heartsSprites; set => heartsSprites = value; }

    // Use this for initialization
    void Start ()
    {
        playerStats = this.GetComponent<PlayerStats>();
        playerStats.Player = this;

        isFacingRight = true;
        anim = GetComponent<Animator>();

        playerStats.BasicFireBallTimer = playerStats.basicFireBallCooldown;
        playerStats.IsbasicFireBallOnCooldown = false;

        playerStats.SuperFireBallTimer = playerStats.superFireBallCooldown;
        playerStats.IsSuperFireBallOnCooldown = false;

        playerStats.DashTimer = playerStats.dashCooldown;
        playerStats.IsDashOnCooldown = false;

        IsWallCollision = false;

        dashCooldownGUI = GameObject.FindGameObjectWithTag("DashCoolDownGUI");
        superFireballCooldownGUI = GameObject.FindGameObjectWithTag("SuperFireBallCoolDownGUI");

        dashCooldownText = dashCooldownGUI.GetComponent<TextMeshProUGUI>();
        superFireballCooldownText = superFireballCooldownGUI.GetComponent<TextMeshProUGUI>();

        heartsGUI = GameObject.FindGameObjectsWithTag("Heart");
        System.Array.Sort(heartsGUI, (x, y) => System.String.Compare(x.gameObject.name, y.gameObject.name));

        heartsSprites = new SpriteRenderer[heartsGUI.Length];

        for (int i = 0; i < 10; i++)
        {
            heartsSprites[i] = heartsGUI[i].GetComponent<SpriteRenderer>();
        }

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
        playerStats.IsbasicFireBallOnCooldown = true;
    }

    public void shootSuperFireball()
    {
        Instantiate(superFireball, shootingPoint.position, shootingPoint.rotation);
        playerStats.IsSuperFireBallOnCooldown = true;
    }
    // Update is called once per frame
    void Update () {


        //shooting basic fireball
        if (Input.GetKeyDown(basicFireballKey) && !playerStats.IsbasicFireBallOnCooldown)
        {
            shootBasicFireBall();
        }     
        //start cooldown timer for basic fireball
        if (playerStats.IsbasicFireBallOnCooldown)
        {
            playerStats.BasicFireBallTimer -= Time.deltaTime;
            if(playerStats.BasicFireBallTimer <= 0)
            {
                playerStats.IsbasicFireBallOnCooldown = false;
                playerStats.BasicFireBallTimer = playerStats.basicFireBallCooldown;
            }
        }

        //shooting super fireball
        if (Input.GetKeyDown(superFireballKey) && !playerStats.IsSuperFireBallOnCooldown)
        {
            shootSuperFireball();
        }
        if (playerStats.IsSuperFireBallOnCooldown)
        {
            playerStats.SuperFireBallTimer -= Time.deltaTime;
            superFireballCooldownText.text = System.String.Format("{0:0.0}", playerStats.SuperFireBallTimer);

            if (playerStats.SuperFireBallTimer <= 0)
            {
                playerStats.IsSuperFireBallOnCooldown = false;
                superFireballCooldownText.text = "Ready";
                playerStats.SuperFireBallTimer = playerStats.superFireBallCooldown;
            }
        }

        if (Input.GetKey(Teleport) && !isTeleporting)
        {
            if (!playerStats.IsDashOnCooldown)
            {
                isTeleporting = true;
                playerStats.IsDashOnCooldown = true;
            }
        }
        if (playerStats.IsDashOnCooldown)
        {
            playerStats.DashTimer -= Time.deltaTime;
            dashCooldownText.text = System.String.Format("{0:0.0}", playerStats.DashTimer);
            if (playerStats.DashTimer <= 0)
            {
                playerStats.IsDashOnCooldown = false;
                dashCooldownText.text = "Ready";
                playerStats.DashTimer = playerStats.dashCooldown;
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

        if (Input.GetKey(L) && !IsWallCollision)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, GetComponent<Rigidbody2D>().velocity.y);
            if (isFacingRight)
            {
                flip();
                isFacingRight = false;
            }   
        }

        if(Input.GetKey(R)&&!IsWallCollision)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);

            if (!isFacingRight)
            {
                flip();
                isFacingRight = true;
            }
        }

        if (GetComponent<Rigidbody2D>().velocity.y == 0) isWallCollision = false;

        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));

	}


    void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        if (collision.gameObject.tag == "Platform" && rb.velocity.y != 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, -5f);
            IsWallCollision = true;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform") IsWallCollision = false;

    }

}
