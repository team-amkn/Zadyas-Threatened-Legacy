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
            Destroy(instance.gameObject);
            instance = this;
        }
        
        

        DontDestroyOnLoad(this.gameObject);
    }


    public void PlaySingle(AudioClip audio, float volume, float minPitch, float maxPitch) {
        FXSrc.clip = audio;
        FXSrc.volume = volume;
        FXSrc.pitch = Random.Range(minPitch, maxPitch);
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
