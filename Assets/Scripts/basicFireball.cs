using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicFireball : Projectile
{

    private Transform axel;
    //private bool hasCollided = false;

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
        /*if (this.hasCollided == true)
        {
            return;
        }*/

         Debug.Log(other.name);
        if (other.tag == "Wraith")
        {
            other.GetComponent<Wraith>().InstantDeath();
            Destroy(other.gameObject, .1f);

            Destroy(this.gameObject, 0f);
            //this.hasCollided = true;

        }
        else if (other.tag == "GolemHitbox")
        {
            Debug.Log("Golem trigerred");
            other.GetComponentInParent<Golem>().InstantDeath();
            Destroy(this.gameObject, 0f);
           

            // this.hasCollided = true;
        }

        else if (other.tag == "Aravos")
        {

            other.GetComponent<Aravos>().TakeDamage(damage);
            Destroy(this.gameObject);
            //this.hasCollided = true;

        }
        else if (other.tag == "Wall")
        {

            Destroy(this.gameObject);
            //this.hasCollided = true;

        }



    }

}
