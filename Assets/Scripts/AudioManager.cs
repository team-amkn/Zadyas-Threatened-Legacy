using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource FXSrc;
    public AudioSource BGMusicSrc;
    public static AudioManager instance = null;

    // Start is called before the first frame update
    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }


    public void PlaySingle(AudioClip audio, float volume, float minPitch, float maxPitch) {
        FXSrc.clip = audio;
        FXSrc.volume = Mathf.Clamp(volume, 0f, 1f); //So if the function is passed a value outside the range it gets handled here
        float randomPitch = Random.Range(minPitch, maxPitch);
        FXSrc.pitch = randomPitch;
        FXSrc.Play();
    }

    public void RandomizeFX(params AudioClip[] audioClips) {
        int randomIndex = Random.Range(0, audioClips.Length); //I don't do (length - 1) beacuse the second parameter is not included
        FXSrc.clip = audioClips[randomIndex];
        FXSrc.Play();
    }   


    void Update()
    {

    }
}
