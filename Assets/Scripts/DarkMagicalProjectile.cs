using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkMagicalProjectile : Projectile
{

    private Transform wraithEnemy;
    public Transform axel;
    private Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        wraithEnemy = FindObjectOfType<Wraith>().GetComponent<Transform>();
        sourceGameObject = wraithEnemy; 
        axel =  FindObjectOfType<Player>().GetComponent<Transform>();
        shootProjectile();
        Rigidbody2D rd = GetComponent<Rigidbody2D>();

        Vector2 moveDirection = (axel.transform.position - transform.position).normalized * Mathf.Abs(speed);
        rd.velocity = new Vector2(moveDirection.x, moveDirection.y);

    }

    // Update is called once per frame
    protected override void LateUpdate()
    {
       
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            Destroy(this.gameObject, 0.1f);
        }

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
