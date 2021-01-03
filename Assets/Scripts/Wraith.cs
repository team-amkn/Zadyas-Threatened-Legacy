using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wraith : Minion
{
    public Transform darkMagicalBallPoint;
    public GameObject projectile;

    IEnumerator shootDarkMagicalball()
    {
      while (true)
        {
            GameObject obj = Instantiate(projectile, darkMagicalBallPoint.position, darkMagicalBallPoint.rotation);
            obj.GetComponent<DarkMagicalProjectile>().SourceGameObject = this.transform;
            obj.GetComponent<DarkMagicalProjectile>().SourcePosition = this.transform.position;
            yield return new WaitForSeconds(attackCooldown);
        }
        
    }
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        this.enemy = this.GetComponent<Transform>();

        isAttackOnCooldown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerWithinLineOfSight())
        {
            FacePlayer();
            if (!(isAttackOnCooldown))
            {
                Debug.Log("Line of Sight is: " + lineOfSight + " Is player within line of sight? " + isPlayerWithinLineOfSight());
                StartCoroutine(shootDarkMagicalball());
                isAttackOnCooldown = true; 
            }
            
        }
        
    }


    public override void die()
    {
        base.die();
        LevelManager3 levelManger = FindObjectOfType<LevelManager3>();
        //If level manager 3 was not found, this means we are not in Level 3, so we won't decrease the count
        if (levelManger)
        {
            levelManger.currWraithCount--;
        }
    }

}
