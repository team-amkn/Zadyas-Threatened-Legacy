using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject intialCheckPoint;
    protected PlayerStats playerStats;
    private static GameObject currCheckPoint;
    public static float leftLevelBoundary, rightLevelBoundary;
    
  

    public static GameObject CurrCheckPoint { get => currCheckPoint; set => currCheckPoint = value; }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respawn()
    {
        playerStats.transform.position = currCheckPoint.transform.position;
        playerStats.AddHealth(playerStats.maxHealth);
    }


}
