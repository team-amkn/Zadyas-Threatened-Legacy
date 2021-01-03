using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float speed;
    protected PlayerStats playerStats;
    protected Transform enemy;
    protected bool scalePositiveWhenFacingRight = true;
    public float attackCooldown;
    protected bool isAttackOnCooldown = false;

    // Start is called before the first frame update
    protected virtual void Start()
    {
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
}
