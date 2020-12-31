using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : Stats
{
    public float dashCoolDown;
    public float superFireBallCooldown, fireBallCooldown;


     void Start()
    {
        ResetHealth();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public override void TakeDamage(float dmg)
    {
        base.TakeDamage(dmg);

    }

    public override void Killed()
    {

    }


}
