using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wraith : Enemy
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        this.enemy = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerWithinLineOfSight())
        {
            FacePlayer();
            // Shoot Cursed Fireall at player
            // TODO
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
