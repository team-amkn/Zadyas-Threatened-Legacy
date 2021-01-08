using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float speed;
    protected PlayerStats playerStats;
    protected bool scalePositiveWhenFacingRight = true;
    public float attackCooldown;
    protected bool isAttackOnCooldown = false;
    public Animator anim;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        this.anim = this.gameObject.GetComponent<Animator>();
    }

    protected virtual void FacePlayer()
    {
        //Calculate distance between player and enemy to know if the player is on the left or on the right
        var x_distance = playerStats.transform.position.x - this.gameObject.transform.position.x;
        float newXScale;
        //The player is on the right
        if (x_distance > 0)
        {
            newXScale = System.Math.Abs(this.gameObject.transform.localScale.x);
        }
        else //The player is on the left
        {
            newXScale = -System.Math.Abs(this.gameObject.transform.localScale.x);
        }
        //To handle the case if the sprite itself was facing left initially and then modified in the inspector to face right by setting its x localscale to negtive value (The frog for example)
        if (!scalePositiveWhenFacingRight) newXScale = -newXScale;

        this.gameObject.transform.localScale = new Vector3(newXScale, this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z);
    }
}
