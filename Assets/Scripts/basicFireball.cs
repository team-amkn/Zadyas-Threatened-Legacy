using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicFireball : Projectile
{

    private Transform axel;
    private bool hasCollided;

    //private bool hasCollided = false;

    void Start()
    {
        hasCollided = false;
        axel = FindObjectOfType<Player>().GetComponent<Transform>();
        sourceGameObject = axel;
        shootProjectile();
    }

    // Update is called once per frame
    protected override void LateUpdate()
    {
        base.LateUpdate();
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (this.hasCollided)
        {
            return;
        }

        if (other.tag == "Wraith")
        {
            other.GetComponent<Wraith>().InstantDeath();
            Destroy(this.gameObject, 0f);
            this.hasCollided = true;

        }
        else if (other.tag == "GolemHitbox")
        {
            other.GetComponentInParent<Golem>().InstantDeath();
            Destroy(this.gameObject, 0f);
            this.hasCollided = true;
        }

        else if (other.tag == "Aravos")
        {
            other.GetComponent<Aravos>().TakeDamage(damage);
            Destroy(this.gameObject);
            this.hasCollided = true;
        }
        else if (other.tag == "Wall")
        {
            Destroy(this.gameObject);
            this.hasCollided = true;
        }
    }

}
