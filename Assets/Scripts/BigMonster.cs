using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigMonster : Enemy
{
    public Transform mouth;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        scalePositiveWhenFacingRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        FacePlayer();

        Vector3 target = new Vector3(playerStats.transform.position.x, playerStats.transform.position.y, playerStats.transform.position.z);
        // Make sure frog doesn't sink deeper than ground
        //if (target.y < -1.55f) target.y = -1.55f;
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerStats.InstantDeath();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag != "Ground")
            Physics2D.IgnoreCollision(collision.otherCollider, collision.collider);
    }
}