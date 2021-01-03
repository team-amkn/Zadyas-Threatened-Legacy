using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkMagicalProjectile : Projectile
{
    public Transform axel;
    private Vector3 target;
    Rigidbody2D rb;

    void Start()
    {
        axel = FindObjectOfType<Player>().GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = ((axel.position - this.transform.position).normalized) * speed;
    }
    // Update is called once per frame
    protected void Update()
    {
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            Destroy(this.gameObject, 0.1f);
        }
        calculateTravelDistance();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Player")
        {
            FindObjectOfType<PlayerStats>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
        if(other.tag == "wall")
        {
            Destroy(this.gameObject);
        }
        
    }
}
