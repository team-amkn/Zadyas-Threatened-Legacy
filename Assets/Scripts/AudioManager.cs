using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    protected static float volumeMultiplier = 1f;
    public AudioSource FXSrc;
    public AudioSource BGMusicSrc;
    public AudioSource MenuSFX;
    public static AudioManager instance = null;

    private static float originalBGMusicValue = 0.2f;

    public static void SetVolumeMultiplier(Slider slider)
    {
        volumeMultiplier = slider.value;
        Cutscene cutscene = FindObjectOfType<Cutscene>();
        if (cutscene)
        {
            cutscene.GetComponent<VideoPlayer>().SetDirectAudioVolume(0, 0.75f * volumeMultiplier);
        }
        if (instance.BGMusicSrc)
        {
            instance.BGMusicSrc.volume = originalBGMusicValue * volumeMultiplier;
        }
    }

    public static float GetVolumeMultiplier()
    {
        return volumeMultiplier;
    }
    // Start is called before the first frame update
    protected virtual void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(instance.gameObject);
            instance = this;
        }
        if (instance.BGMusicSrc)
        {
            instance.BGMusicSrc.volume = originalBGMusicValue * volumeMultiplier;
        }

        DontDestroyOnLoad(this.gameObject);
    }


    public void PlaySingle(AudioClip audio, float volume, float minPitch, float maxPitch)
    {
        FXSrc.clip = audio;
        FXSrc.volume = volume * volumeMultiplier;
        FXSrc.pitch = Random.Range(minPitch, maxPitch);
        FXSrc.Play();
    }

    public void RandomizeFX(params AudioClip[] audioClips)
    {
        int randomIndex = Random.Range(0, audioClips.Length); //I don't do (length - 1) beacuse the second parameter is not included
        FXSrc.clip = audioClips[randomIndex];
        FXSrc.volume = 0.12f * volumeMultiplier;
        FXSrc.Play();
    }


    void Update()
    {

    }
}
