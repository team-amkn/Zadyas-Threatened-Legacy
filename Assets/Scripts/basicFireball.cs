using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicFireball : Projectile
{

    private Transform axel;

   protected override void Start()
    {
        //sourceGameObject = GameObject.FindWithTag("Player");
        base.Start();
        

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
