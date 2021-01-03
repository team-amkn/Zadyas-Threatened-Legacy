using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperFireball : Projectile
{
    private Transform axel;
    private int enemiesCount = 0;
    public int maxEnemyHit;
    void Start()
    {
        axel = FindObjectOfType<Player>().GetComponent<Transform>();
        SourceGameObject = axel;
        shootProjectile();
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
    }

    // Update is called once per frame
    protected void FixedUpdate()
    {
        calculateTravelDistance();
    }

    protected override void calculateTravelDistance()
    {
        if (this.transform == null) return;
        distanceTravelled = Mathf.Abs(this.transform.position.x - SourceGameObject.transform.position.x);

        if (distanceTravelled >= maximumTravelledDistance)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Wraith")
        {
            other.GetComponentInParent<Wraith>().die();
            enemiesCount++;
        }
        if (other.tag == "GolemHitbox")
        {
            other.GetComponentInParent<Golem>().die();
            enemiesCount++;
        }

        if (other.tag == "Aravos")
        {
            other.GetComponentInParent<Aravos>().TakeDamage(damage);
            enemiesCount++;
        }

        if (enemiesCount >= maxEnemyHit)
        {
            Destroy(this.gameObject);
        }

    }
}