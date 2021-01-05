using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public float health;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerStats playerStats = other.GetComponent<PlayerStats>();
            if (playerStats.Health < playerStats.maxHealth)
            {
                playerStats.AddHealth(health);
                Destroy(this.gameObject, 0.1f); 
            }
        }
    }
}
