using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicFireball : Projectile
{

    private Transform axel;

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
       if(other.tag == "Minion")
        {

        }
       if(other.tag == "Aravos")
        {

        }

        //Destroy(this.gameObject);
    }
    
}
