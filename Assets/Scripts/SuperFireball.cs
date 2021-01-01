using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperFireball : Projectile
{
    private Transform axel;
    public int enemiesCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        axel = FindObjectOfType<Player>().GetComponent<Transform>();
        sourceGameObject = axel;
        shootProjectile();
    }

    // Update is called once per frame
    protected override void LateUpdate()
    {
        base.LateUpdate();
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Wraith")
        {
            other.GetComponentInParent<Wraith>().InstantDeath();
            Destroy(other.gameObject, .2f);
            enemiesCount++;
        }
        if (other.tag == "Golem")
        {
            other.GetComponentInParent<Golem>().InstantDeath();
            Destroy(other.gameObject, .2f);
            enemiesCount++;
        }

        if (other.tag == "Aravos")
        {
            other.GetComponentInParent<Aravos>().InstantDeath();
            enemiesCount++;
        }

        if (enemiesCount >= 3)
        {
            Destroy(this.gameObject);
        }
    }
}
