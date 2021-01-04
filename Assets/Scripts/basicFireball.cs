using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicFireball : AxelFireball
{

    private bool hasCollided = false;

    protected void Update()
    {
        this.calculateTravelDistance();
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (this.hasCollided)
        {
            return;
        }

        if (other.tag == "Wraith")
        {
            other.GetComponent<Wraith>().die();
            Destroy(this.gameObject, 0f);
            this.hasCollided = true;

        }
        else if (other.tag == "GolemHitbox")
        {
            other.GetComponentInParent<Golem>().die();
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
