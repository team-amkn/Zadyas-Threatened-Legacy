using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
    public KeyCode escape;
    private VideoPlayer video;
    // Start is called before the first frame update
    void Start()
    {
        video = this.GetComponent<VideoPlayer>();
        video.SetDirectAudioVolume(0, 0.75f * AudioManager.GetVolumeMultiplier());
        video.loopPointReached += GoToNextScene;
    }


    public void GoToNextScene(VideoPlayer video)
    {
        int nextSceneIndex = (SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(nextSceneIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
