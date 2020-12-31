using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : Stats
{
    public float lineOfSight;
    public PlayerStats playerStats;
    public Transform enemy;
    public bool scalePositiveWhenFacingRight = true;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        ResetHealth();
        playerStats = FindObjectOfType<PlayerStats>();

    }

    protected virtual void FacePlayer()
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
        if (!scalePositiveWhenFacingRight) new_x = -new_x;
       enemy.transform.localScale = new Vector3(new_x, enemy.transform.localScale.y, enemy.transform.localScale.z);
    }

    public bool isPlayerWithinLineOfSight()
    {
        if (lineOfSight >= Mathf.Abs(playerStats.transform.position.x - transform.position.x))
            return true;
        else
            return false;
    }
}
