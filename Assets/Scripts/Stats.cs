using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{

    public float damage;
    public float maxHealth;
    private float health;
    protected GameObject obj;

    public float Health { get => health; }


    public virtual void TakeDamage(float dmg)
    {

        health = Mathf.Clamp(health - dmg, 0, maxHealth);

        if (health == 0) Killed();
        
    }

    public virtual void Killed()
    {
        Destroy(this.obj, 0f);
    }

    public virtual void InstantDeath()
    {
        TakeDamage(maxHealth);

    }

    public virtual void AddHealth(float inc)
    {

        health = Mathf.Clamp(health + inc, 0, maxHealth);
    }

    public void ResetHealth()
    {
        health = maxHealth;
    }


}
