using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public GameObject intialCheckPoint;
    protected PlayerStats playerStats;
    public static Player player;
    private static GameObject currCheckPoint;
    private static float superFireBallCooldown, dashCooldown;
    public static float leftLevelBoundary, rightLevelBoundary;
    public static bool arePlayerStatsSaved = false;
    public GameObject pauseMenu, gameOverMenu;
    public static LevelManager currLevelManger;
    protected static bool isGamePaused = false;
    private static bool isPlayerDead = false;
    private KeyCode escape;
    public KeyCode Escape { get => escape; set => escape = value; }
    public static GameObject CurrCheckPoint { get => currCheckPoint; set => currCheckPoint = value; }
    public static bool IsPlayerDead { get => isPlayerDead; set => isPlayerDead = value; }


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

    public static void FreezeScene()
    {
        player.enabled = false;
        Time.timeScale = 0;
    }

    public static void UnFreezeScene()
    {
        player.enabled = true;
        Time.timeScale = 1;
    }


    public void ExitGame()
    {
        Debug.Log("Exit game");
        Application.Quit();
    }

    public void ResumeGame()
    {
        Destroy(GameObject.FindGameObjectWithTag("pauseMenu"));
        isGamePaused = false;
        AudioManager.instance.BGMusicSrc.UnPause();
        LevelManager.UnFreezeScene();
    }

    public virtual void Respawn()
    {
            isPlayerDead = false;
            Destroy(GameObject.FindGameObjectWithTag("gameOverCanvas"));
            AudioManager.instance.BGMusicSrc.UnPause();
            UnFreezeScene();
            playerStats.GetComponent<SpriteRenderer>().enabled = true;
            playerStats.transform.position = currCheckPoint.transform.position;
            playerStats.AddHealth(playerStats.maxHealth);
        }

    public static GameObject FindObjectWithTagInChildrenRecursive(GameObject parentGameObject, string tag)
    {
        Transform parent = parentGameObject.transform;
        GameObject result = null;
        if (parent.CompareTag(tag)) return parent.gameObject;
        foreach (Transform child in parent)
        {
            if (child.CompareTag(tag))
            {
                result = child.gameObject;
            }
            if (result) break;
            result = FindObjectWithTagInChildrenRecursive(child.gameObject, tag);
        }
        return result;
    }

    public static void PlayerDead()
    {
        currLevelManger.playerStats.GetComponent<SpriteRenderer>().enabled = false;
        AudioManager.instance.PlaySingle(player.gameOverAudio, 0.2f, 1f, 1f);
        LevelManager.FreezeScene();
        AudioManager.instance.BGMusicSrc.Pause();
        GameObject gameover = Instantiate(LevelManager.currLevelManger.gameOverMenu);
        GameObject restartButton = FindObjectWithTagInChildrenRecursive(gameover, "RestartLevelButton");
        GameObject respawnButton = FindObjectWithTagInChildrenRecursive(gameover, "RespawnButton");
        
        //Remove level 3 option to respawn at checkpoint
        if (LevelManager.currLevelManger.GetComponent<LevelManager3>())
        {
            respawnButton.SetActive(false);
            restartButton.GetComponent<Button>().onClick.AddListener(currLevelManger.RestartLevel);
        }
        else {
            restartButton.GetComponent<Button>().onClick.AddListener(currLevelManger.RestartLevel);
            respawnButton.GetComponent<Button>().onClick.AddListener(currLevelManger.Respawn);
        }
    }


    public void PauseGame()
    {
        LevelManager.FreezeScene();
        AudioManager.instance.BGMusicSrc.Pause();
        isGamePaused = true;
        GameObject pausemenu = Instantiate(LevelManager.currLevelManger.pauseMenu);
        GameObject resumeButton = FindObjectWithTagInChildrenRecursive(pausemenu, "ResumeButton");
        GameObject quitButton = FindObjectWithTagInChildrenRecursive(pausemenu, "QuitButton");
        resumeButton.GetComponent<Button>().onClick.AddListener(currLevelManger.ResumeGame);
        quitButton.GetComponent<Button>().onClick.AddListener(currLevelManger.ExitGame);
    }

    public void RestartLevel()
    {
        isPlayerDead = false;
        Destroy(GameObject.FindGameObjectWithTag("gameOverCanvas"));
        UnFreezeScene();
        AudioManager.instance.BGMusicSrc.Play(); //To replay level music
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    protected virtual void Start()
    {
        player = FindObjectOfType<Player>();
        playerStats = FindObjectOfType<PlayerStats>();
        escape = FindObjectOfType<Player>().escape;
    }


    protected void Update()
    {
        if (Input.GetKey(escape))
        {
            if(!isGamePaused) PauseGame();
        }

    }

}





