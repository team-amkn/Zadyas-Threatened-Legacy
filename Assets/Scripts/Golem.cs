using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Golem : Enemy
{

    public float maxSpeed = 3f;
    public float patrolAreaRadius;
    private float leftAreaBoundary, rightAreaBoundary;
    public bool onPatrolMovingLeft;
    private bool wasChasingPlayer = false;

    // Start is called before the first frame update
    protected override void Start()
    {
        obj = this.gameObject;
        base.Start();
        ResetHealth();
        Physics2D.IgnoreCollision(playerStats.GetComponent<BoxCollider2D>(), GetComponents<BoxCollider2D>()[1]);
        this.enemy = this.GetComponent<Transform>();
        leftAreaBoundary = transform.position.x - patrolAreaRadius;
        rightAreaBoundary = transform.position.x + patrolAreaRadius;
        onPatrolMovingLeft = (Random.value > 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerWithinLineOfSight())
        {
            FacePlayer();
            if (this.transform.position.x > playerStats.transform.position.x)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(playerStats.transform.position.x + 0.4f, transform.position.y, transform.position.z), maxSpeed * Time.deltaTime);
            }
            else {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(playerStats.transform.position.x - 0.4f, transform.position.y, transform.position.z), maxSpeed * Time.deltaTime);
            }
            wasChasingPlayer = true;
        }

        else
        {
            Patrol();
        }
    }

    IEnumerator AttackTimer()
    {
        while (isBasicAttackOnCooldown)
        {
            yield return new WaitForSeconds(basicAttackCooldown);
            isBasicAttackOnCooldown = false; //To stop couroutine
            GetComponent<BoxCollider2D>().enabled = true;
            Debug.Log("BECOME NOT ON COOLDOWN");
        }

    }


    void Patrol()
    {
        if (wasChasingPlayer)
        {
            wasChasingPlayer = false;
            leftAreaBoundary = transform.position.x - patrolAreaRadius;
            rightAreaBoundary = transform.position.x + patrolAreaRadius;
        }

        if (transform.position.x >= rightAreaBoundary)
        {
            onPatrolMovingLeft = true;
        }
        if (transform.position.x <= leftAreaBoundary)
        {
            onPatrolMovingLeft = false;
        }

        float x_movment, x_scale = Mathf.Abs(transform.localScale.x);
        if (onPatrolMovingLeft)
        {
            x_movment = leftAreaBoundary;
            x_scale = -x_scale;
        }
        else
        {
            x_movment = rightAreaBoundary;
        }
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(x_movment, transform.position.y, transform.position.z), maxSpeed * Time.deltaTime);
        transform.localScale = new Vector3(x_scale, transform.localScale.y, transform.localScale.z);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!isBasicAttackOnCooldown)
            {
                //Play attack animation
                isBasicAttackOnCooldown = true;
                GetComponent<BoxCollider2D>().enabled = false;
                StartCoroutine(AttackTimer());
                playerStats.TakeDamage(damage);
                Debug.Log("Axel Health: " + playerStats.Health);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Wall" || other.gameObject.tag == "Golem")
        {
            onPatrolMovingLeft = !onPatrolMovingLeft;
        }
    }

    public override void Killed()
    {
        base.Killed();
        LevelManager3 levelManger = FindObjectOfType<LevelManager3>();
        if (levelManger)
        {
            levelManger.currGolemCount--;
        }
    }

}
