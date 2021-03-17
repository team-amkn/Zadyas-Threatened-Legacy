using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreAxelCollision : MonoBehaviour
{

    PlayerStats player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerStats>();
        Physics2D.IgnoreCollision(player.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
