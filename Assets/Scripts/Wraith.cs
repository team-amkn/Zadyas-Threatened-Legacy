using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wraith : Enemy
{

    public Transform darkMagicalBallPoint;
    public GameObject projectile;



    IEnumerator shootDarkMagicalball()
    {
      while (true)
        {
            Instantiate(projectile, darkMagicalBallPoint.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(basicAttackCooldown);
        }
        
    }
    // Start is called before the first frame update
    protected override void Start()
    {
        obj = this.gameObject;
        base.Start();
        ResetHealth();
        this.enemy = this.GetComponent<Transform>();

        isBasicAttackOnCooldown = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerWithinLineOfSight())
        {
            FacePlayer();
            // Shoot Cursed Fireall at player
            // TODO
            if (!(isBasicAttackOnCooldown))
            {
                StartCoroutine(shootDarkMagicalball());
                isBasicAttackOnCooldown = true;
            }
            
        }
        
    }


    public override void Killed()
    {
        base.Killed();
        LevelManager3 levelManger = FindObjectOfType<LevelManager3>();
        if (levelManger)
        {
            levelManger.currWraithCount--;
        }
    }

}
