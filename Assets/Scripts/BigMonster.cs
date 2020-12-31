using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigMonster : Enemy
{
    public float maxSpeed = 1f;
    public Transform mouth;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        this.enemy = this.GetComponent<Transform>();
        scalePositiveWhenFacingRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        FacePlayer();
        // Moves on X-Axis only
        //transform.position = Vector3.MoveTowards(transform.position, new Vector3(playerStats.transform.position.x, transform.position.y, transform.position.z), maxSpeed * Time.deltaTime);

        //Follows player in air
        transform.position = Vector3.MoveTowards(transform.position, playerStats.transform.position, maxSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            FindObjectOfType<PlayerStats>().InstantDeath();
        }
    }
 
    
}
