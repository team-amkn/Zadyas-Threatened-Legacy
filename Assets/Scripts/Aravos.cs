using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aravos : Enemy
{

    public float lightninigBoltsCooldown, minionSummonCooldown, cursedFireballCooldown;
    private LevelManager3 levelManager;
    private Animator anim;

    private bool lightninigBoltsReady, minionSummonReady, cursedFireballReady;
    public GameObject wraith, golem, lightning;
    public Transform lightningTransform1, lightningTransform2, lightningTransform3, lightningTransform4;

    // Start is called before the first frame update
    protected override void Start()
    {
        obj = this.gameObject;
        base.Start();
        this.enemy = this.GetComponent<Transform>();
        anim = GetComponent<Animator>();
        levelManager = FindObjectOfType<LevelManager3>();
        lightninigBoltsReady = minionSummonReady = cursedFireballReady = true;
    }

    // Update is called once per frame
    void Update()
    {
        FacePlayer();

        if ( Health <= 0)
        {
            Killed();
        }

        if (Health <= 100 && cursedFireballReady)
        {

            StartCoroutine(FireCursedFireball());
            cursedFireballReady = false;
        }
        if (Health <= 75 && minionSummonReady)
        {
            StartCoroutine(SummonMinions());
            minionSummonReady = false;
        }
        if (Health <= 25 && lightninigBoltsReady)
        {
            StartCoroutine(SummonLightningBolts());
            lightninigBoltsReady = false;
        }
    }


    IEnumerator SummonMinions()
    {

        while (true)
        {
            if (levelManager.currGolemCount < levelManager.maxGolemsCount)
            {
                GameObject spawn = Instantiate(golem, new Vector3(-5.47f, -3.49f, 0f), Quaternion.identity);
                spawn.GetComponent<Golem>().lineOfSight *= 1000;
                levelManager.currGolemCount++;
            }

            /*for(int i = 0; i < 2; i++)
            {
                if (levelManager.currWraithCount >= levelManager.maxWraithCount) break;
                GameObject spawn =Instantiate(wraith, new Vector3(1.452f, -2.885f, 0f), Quaternion.identity);
                spawn.GetComponent<Wraith>().lineOfSight *= 1000;
                levelManager.currWraithCount++;
            }*/
        
            yield return new WaitForSeconds(minionSummonCooldown);

        }

    }

    IEnumerator FireCursedFireball()
    {
        while (true)
        {
         ;
            yield return new WaitForSeconds(cursedFireballCooldown);
        }
    }

    IEnumerator SummonLightningBolts()
    {
        while (true)
        {
            Instantiate(lightning, lightningTransform1);
            Instantiate(lightning, lightningTransform2);
            Instantiate(lightning, lightningTransform3);
            Instantiate(lightning, lightningTransform4);
            yield return new WaitForSeconds(lightninigBoltsCooldown);
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
