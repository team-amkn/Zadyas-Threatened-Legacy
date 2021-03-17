using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject optionsMenu;

    public void PlayGame()
    {
        PlaySound();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlaySound()
    {
        AudioManager.instance.MenuSFX.volume = 1f * AudioManager.GetVolumeMultiplier();
        AudioManager.instance.MenuSFX.Play();
    }

    public void OpenOptionsMenu()
    {
        Instantiate(optionsMenu);
    }

    public void QuitGame()
    {
        Debug.Log("Application quit.");
        PlaySound();
        Application.Quit();
    }
}
