using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : Enemy
{
    public bool isFacingRight = false;
    public float maxSpeed = 3f;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        this.enemy = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        FacePlayer();
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(playerStats.transform.position.x, transform.position.y, transform.position.z), maxSpeed * Time.deltaTime);
    }

    public void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Wall" || other.tag == "Enemy") Flip();
        if (other.tag == "Player")
        {
            FindObjectOfType<PlayerStats>().TakeDamage(damage);
            Flip();
        }

    }
}
