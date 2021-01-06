using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public GameObject intialCheckPoint;
    protected PlayerStats playerStats;
    private static GameObject currCheckPoint;
    private static float superFireBallCooldown, dashCooldown;
    public static float leftLevelBoundary, rightLevelBoundary;
    public static bool arePlayerStatsSaved = false;

    public static GameObject CurrCheckPoint { get => currCheckPoint; set => currCheckPoint = value; }

    public static void LoadPlayerStats(PlayerStats playerStats)
    {
        playerStats.superFireBallCooldown = superFireBallCooldown;
        playerStats.dashCooldown = dashCooldown;
    }

    public static void SavePlayerStats(PlayerStats playerStats)
    {
        superFireBallCooldown = playerStats.superFireBallCooldown;
        dashCooldown = playerStats.dashCooldown;
        arePlayerStatsSaved = true;
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Respawn()
    {

            GameObject.FindGameObjectWithTag("gameOverCanvas").GetComponent<Canvas>().enabled = false;
            GameObject.FindGameObjectWithTag("RespawnButton").GetComponent<Button>().enabled = false;
            GameObject.FindGameObjectWithTag("RestartLevelButton").GetComponent<Button>().enabled = false;
            playerStats.Player.enabled = true;
            playerStats.GetComponent<SpriteRenderer>().enabled = true;
            playerStats.transform.position = currCheckPoint.transform.position;
            playerStats.AddHealth(playerStats.maxHealth);
        }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}





