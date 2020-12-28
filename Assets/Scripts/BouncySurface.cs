using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncySurface : MonoBehaviour
{
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
    }

    

    // Update is called once per frame

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") {
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(player.GetComponent<Rigidbody2D>().velocity.x, 12);
        }    
    }

    void Update()
    {
        
    }
}
