using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aravos : Enemy
{
    public AravosHealthbar healthbar;
    public float HP;

    public float lightninigBoltsCooldown, minionSummonCooldown, cursedFireballCooldown;
    private LevelManager3 levelManager;

    private bool isDead = false;


    private bool lightninigBoltsReady, minionSummonReady, cursedFireballReady;
    public GameObject wraith, golem, lightning, cursedFireBall;
    public Transform lightningTransform1, lightningTransform2, lightningTransform3, lightningTransform4, cursedBallPoint;


    public AudioClip evilLaugh1;
    public AudioClip evilLaugh2;
    public AudioClip evilLaugh3;
    public AudioClip aravosDeath;


    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        this.enemy = this.GetComponent<Transform>();

        levelManager = FindObjectOfType<LevelManager3>();
        lightninigBoltsReady = minionSummonReady = cursedFireballReady = true;
        StartCoroutine(EvilLaugh());
        healthbar.setMaxHealth(HP);
    }

    // Update is called once per frame
    void Update()
    {

        if (!isDead) {
            FacePlayer();

            if (HP <= 100 && cursedFireballReady)
            {
                StartCoroutine(FireCursedFireball());
                cursedFireballReady = false;
            }
            if (HP <= 75 && minionSummonReady)
            {
                StartCoroutine(SummonMinions());
                minionSummonReady = false;
            }
            if (HP <= 25 && lightninigBoltsReady)
            {
                StartCoroutine(SummonLightningBolts());
                lightninigBoltsReady = false;
            }
        }
    }


    IEnumerator SummonMinions()
    {
        while (!isDead)
        {
            if (levelManager.currGolemCount < levelManager.maxGolemsCount)
            {
                GameObject spawn = Instantiate(golem, new Vector3(-5.47f, -3.49f, 0f), Quaternion.identity);
                levelManager.currGolemCount++;
            }

            if (levelManager.currWraithCount == 0)
            {
                Instantiate(wraith, new Vector3(this.transform.position.x - 1.8f, this.transform.position.y + 1f, this.transform.position.z), Quaternion.identity);
                Instantiate(wraith, new Vector3(this.transform.position.x + 1.8f, this.transform.position.y + 1f, this.transform.position.z), Quaternion.identity);
                levelManager.currWraithCount += 2;
            };
            anim.Play("Summon");
            yield return new WaitForSeconds(minionSummonCooldown);
        }

    }

    IEnumerator EvilLaugh()
    {
        while (!isDead)
        {
            anim.Play("Rage");
            AudioManagerLevel3 instance = (AudioManagerLevel3)(AudioManager.instance);
            instance.RandomizeAravosFX(evilLaugh1, evilLaugh2, evilLaugh3);
            yield return new WaitForSeconds(5);
        }

    }


    IEnumerator FireCursedFireball()
    {
        while (!isDead)
        {
            anim.Play("Shooting");
            GameObject obj = Instantiate(cursedFireBall, cursedBallPoint.position, cursedBallPoint.rotation);
            obj.GetComponent<DarkMagicalProjectile>().SourceGameObject = this.transform;
            obj.GetComponent<DarkMagicalProjectile>().SourcePosition = this.transform.position;
            yield return new WaitForSeconds(cursedFireballCooldown);
        }
    }

    IEnumerator SummonLightningBolts()
    {
        while (!isDead)
        {
            anim.Play("Summon");
            Instantiate(lightning, lightningTransform1);
            Instantiate(lightning, lightningTransform2);
            Instantiate(lightning, lightningTransform3);
            Instantiate(lightning, lightningTransform4);
            yield return new WaitForSeconds(lightninigBoltsCooldown);
        }
    }

    public void TakeDamage(float damage)
    {
        HP -= damage;
        healthbar.setHealth(HP);

        if (HP <= 0)
        {
            isDead = true;
            AudioManager.instance.PlaySingle(aravosDeath, 0.2f, 1f, 1f);
            anim.Play("Death");
            Destroy(this.gameObject, 3f);
            //Shoof hata3mel eh tany lamma ymoot
        }
    }

}
