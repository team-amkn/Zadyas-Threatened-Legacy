using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigMonsterProjectile : Projectile
{
    private Transform bigMonster;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        bigMonster = FindObjectOfType<BigMonster>().GetComponent<Transform>();
        sourceGameObject = bigMonster;
        target = FindObjectOfType<Player>().GetComponent<Transform>();
        shootProjectile();
    }

    // Update is called once per frame
    protected override void LateUpdate()
    {
        base.LateUpdate();
        this.transform.position = Vector3.MoveTowards(this.transform.position,
                                                     target.transform.position, speed * Time.deltaTime);
    }
     void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            FindObjectOfType<PlayerStats>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
