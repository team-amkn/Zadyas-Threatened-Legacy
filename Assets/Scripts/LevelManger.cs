using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManger : MonoBehaviour
{
    private Player player;
    private PlayerStats playerStats;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        playerStats = FindObjectOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respawn()
    {

    }


}
