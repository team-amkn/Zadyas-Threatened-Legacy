using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wraith : Enemy
{

    public Transform darkMagicalBallPoint;
    public GameObject projectile;
    public float projectileCooldown;
    public bool isProjectileOnCooldown;


    IEnumerator shootDarkMagicalball()
    {
      while (true)
        {
            Instantiate(projectile, darkMagicalBallPoint.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(projectileCooldown);
        }
        
    }
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        this.enemy = this.GetComponent<Transform>();
        isProjectileOnCooldown = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerWithinLineOfSight())
        {
            FacePlayer();
            // Shoot Cursed Fireall at player
            // TODO
            if (!(isProjectileOnCooldown))
            {
                StartCoroutine(shootDarkMagicalball());
                isProjectileOnCooldown =true;
            }
            
        }
        
    }

   
    public override void TakeDamage(float dmg)
    {
        base.TakeDamage(dmg);
    }

    public override void Killed()
    {

    }

     
}
