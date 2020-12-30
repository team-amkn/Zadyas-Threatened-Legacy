using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public float damage;

    public PlayerStats playerStats;
    public Transform enemy ;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }

    public void FacePlayer()
    {
        
        var x_diff = playerStats.transform.position.x - enemy.transform.position.x;
        float new_x;
        if (x_diff > 0)
        {
            new_x = System.Math.Abs(enemy.transform.localScale.x);
        }
        else
        {
            new_x = -System.Math.Abs(enemy.transform.localScale.x);
        }
       enemy.transform.localScale = new Vector3(new_x, enemy.transform.localScale.y, enemy.transform.localScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
