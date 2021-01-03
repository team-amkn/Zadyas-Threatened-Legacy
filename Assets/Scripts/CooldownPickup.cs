using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownPickup : MonoBehaviour
{
    public float reductionPercentage;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerStats>().ReduceCooldowns(reductionPercentage);
            Destroy(this.gameObject, 0.1f);
        }
    }


}
