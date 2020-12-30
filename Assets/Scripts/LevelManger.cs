using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManger : MonoBehaviour
{
    public GameObject intialCheckPoint;
    private Player player;
    private PlayerStats playerStats;
    private static GameObject currCheckPoint;

    public static GameObject CurrCheckPoint { get => currCheckPoint; set => currCheckPoint = value; }

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
        player.transform.position = currCheckPoint.transform.position;
        playerStats.health = 5;

    }


}
