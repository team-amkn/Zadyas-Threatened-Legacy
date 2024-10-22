using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Golem : Minion
{
    public float damage;
    public float patrolAreaRadius;
    private float leftAreaBoundary, rightAreaBoundary;
    public bool onPatrolMovingLeft;
    private bool wasChasingPlayer = false;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        Physics2D.IgnoreCollision(playerStats.GetComponent<BoxCollider2D>(), GetComponents<BoxCollider2D>()[1]);
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
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(playerStats.transform.position.x + 0.4f, transform.position.y, transform.position.z), speed * Time.deltaTime);
            }
            else if (this.transform.position.x < playerStats.transform.position.x)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(playerStats.transform.position.x - 0.4f, transform.position.y, transform.position.z), speed * Time.deltaTime);
            }
            if (Mathf.Abs(this.transform.position.x - playerStats.transform.position.x) <= 1f) {
                if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack")) {
                    anim.Play("idle");
                }
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
        while (isAttackOnCooldown)
        {
            yield return new WaitForSeconds(attackCooldown);
            isAttackOnCooldown = false; //To stop couroutine
            GetComponent<BoxCollider2D>().enabled = true;

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

        float x_destination;
        float x_scale = Mathf.Abs(transform.localScale.x);
        if (onPatrolMovingLeft)
        {
            x_destination = leftAreaBoundary;
            x_scale = -x_scale;
        }
        else
        {
            x_destination = rightAreaBoundary;
        }
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(x_destination, transform.position.y, transform.position.z), speed * Time.deltaTime);
        transform.localScale = new Vector3(x_scale, transform.localScale.y, transform.localScale.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!isAttackOnCooldown)
            {
                anim.Play("Attack");
                isAttackOnCooldown = true;
                GetComponent<BoxCollider2D>().enabled = false;
                StartCoroutine(AttackTimer());
                playerStats.TakeDamage(damage);
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

    public override void die()
    {
        base.die();
        LevelManager3 levelManger = FindObjectOfType<LevelManager3>();
        if (levelManger)
        {
            levelManger.currGolemCount--;
        }
    }

}
