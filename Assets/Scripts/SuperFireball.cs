using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperFireball : Projectile
{
    private Transform axel;
    public int enemiesCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        axel = FindObjectOfType<Player>().GetComponent<Transform>();
        sourceGameObject = axel;
        shootProjectile();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Wraith")
        {
            FindObjectOfType<Wraith>().InstantDeath();
            Destroy(other.gameObject, .2f);
            enemiesCount++;
        }
        if (other.tag == "Golem")
        {
            FindObjectOfType<Golem>().InstantDeath();
            Destroy(other.gameObject, .2f);
            enemiesCount++;
        }

        if (other.tag == "Enemy")
        {

            FindObjectOfType<Aravos>().TakeDamage(damage);
            enemiesCount++;

        }
        if (enemiesCount >= 3)
        {
            Destroy(this.gameObject);
        }
    }
}
