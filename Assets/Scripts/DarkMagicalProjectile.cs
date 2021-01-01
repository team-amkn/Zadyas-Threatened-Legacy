using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkMagicalProjectile : Projectile
{

    private Transform wraithEnemy;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        wraithEnemy = FindObjectOfType<Wraith>().GetComponent<Transform>();
        sourceGameObject = wraithEnemy; 
        target =  FindObjectOfType<Player>().GetComponent<Transform>();
        shootProjectile();


    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
       
        if (target.transform.position.x < wraithEnemy.transform.position.x)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position,
                                                     target.transform.position,
                                                     -speed * Time.deltaTime);
        }
        else this.transform.position = Vector3.MoveTowards(this.transform.position,
                                                     target.transform.position, speed * Time.deltaTime);


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
