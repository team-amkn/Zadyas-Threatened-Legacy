//TEST
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aravos : MonoBehaviour
{

    public float health;
    public float lightninigBoltsCooldown, minionSummonCooldown, cursedFireballCooldown;
    private LevelManger3 levelManger;
    private Animator anim;

    private bool lightninigBoltsReady, minionSummonReady, cursedFireballReady;
    public GameObject wraith, golem, lightning;
    public Transform lightningTransform1, lightningTransform2, lightningTransform3, lightningTransform4;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        levelManger = FindObjectOfType<LevelManger3>();
        lightninigBoltsReady = minionSummonReady = cursedFireballReady = true;
}

    // Update is called once per frame
    void Update()
    {

        if ( health <= 0)
        {
            Killed();
        }


        if (health <= 100 && cursedFireballReady)
        {

            StartCoroutine(FireCursedFireball());
            cursedFireballReady = false;
        }
        if (health <= 75 && minionSummonReady)
        {
            StartCoroutine(SummonMinions());
            minionSummonReady = false;
        }
        if (health <= 25 && lightninigBoltsReady)
        {
            StartCoroutine(SummonLightningBolts());
            lightninigBoltsReady = false;
        }
    }

    IEnumerator SummonMinions()
    {

        while (true)
        {
            if (levelManger.currGolemCount < levelManger.maxGolemsCount)
            {
                Instantiate(golem, new Vector3(-5.47f, -3.49f, 0f), Quaternion.identity);
                levelManger.currGolemCount++;
            }

            for(int i = 0; i < 2; i++)
            {
                if (levelManger.currWraithCount >= levelManger.maxWraithCount) break;
                Instantiate(wraith, new Vector3(1.452f, -2.885f, 0f), Quaternion.identity);
                levelManger.currWraithCount++;
            }
        
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

    public void TakeDamage(float dmg)
    {
        
    }

    void Killed()
    {

    }

}
