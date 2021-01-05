using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth;
    private float health;

    //Cooldown related
    private bool isbasicFireBallOnCooldown;
    public float basicFireBallCooldown;
    private float basicFireBallTimer;

    private bool isSuperFireBallOnCooldown;
    public float superFireBallCooldown;
    private float superFireBallTimer;

    public float dashCooldown;
    private float dashTimer;
    private bool isDashOnCooldown;

    private Player player;

    public float BasicFireBallTimer { get => basicFireBallTimer; set => basicFireBallTimer = value; }
    public float SuperFireBallTimer { get => superFireBallTimer; set => superFireBallTimer = value; }
    public float DashTimer { get => dashTimer; set => dashTimer = value; }
    public float Health { get => health;  }
    public bool IsSuperFireBallOnCooldown { get => isSuperFireBallOnCooldown; set => isSuperFireBallOnCooldown = value; }
    public bool IsDashOnCooldown { get => isDashOnCooldown; set => isDashOnCooldown = value; }
    public bool IsbasicFireBallOnCooldown { get => isbasicFireBallOnCooldown; set => isbasicFireBallOnCooldown = value; }

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    private void Start()
    {
        health = maxHealth;
        IsbasicFireBallOnCooldown = false;
        IsSuperFireBallOnCooldown = false;
        IsDashOnCooldown = false;

        player = GetComponent<Player>();
    }

    public virtual void TakeDamage(float dmg)
    {

        for (float i = Health; i > Health - dmg; i -= 0.5f)
        {
            if (i < 0) break;
            player.HeartsSprites[(int)(i * 2)-1].enabled = false;
        }

        health = Mathf.Clamp(health - dmg, 0, maxHealth);


        if (health == 0) {
            //Shoof hata3mel eh lamma ymoot
            Debug.Log("Axel mat he5ohe5o");
        };

    }

    public virtual void InstantDeath()
    {
        TakeDamage(maxHealth);
    }

    public virtual void AddHealth(float inc)
    {
        float new_health = Mathf.Clamp(health + inc, 0, maxHealth);

        for (float i = Health; i < new_health; i += 0.5f)
        {
            player.HeartsSprites[(int)(i * 2) - 1].enabled = true;
        }

        health = new_health;
    }

    public void ReduceCooldowns(float percentage)
    {
        dashCooldown = dashCooldown - ( dashCooldown * percentage );
        superFireBallCooldown = superFireBallCooldown - (superFireBallCooldown * percentage);
    }
}