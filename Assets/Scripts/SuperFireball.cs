using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperFireball : AxelFireball
{
    private int enemiesCount = 0;
    public int maxEnemyHit;

    protected void Update()
    {
        calculateTravelDistance();
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