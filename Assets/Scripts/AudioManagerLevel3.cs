using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerLevel3 : AudioManager
{

    public AudioSource AravosSFX;

    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
    }

    public void PlayAravosSingle(AudioClip audio, float volume, float minPitch, float maxPitch)
    {
        AravosSFX.clip = audio;
        AravosSFX.volume = 0.2f * AudioManager.volumeMultiplier;
        AravosSFX.volume = volume;
        AravosSFX.pitch = Random.Range(minPitch, maxPitch);
        AravosSFX.Play();
    }

    public void RandomizeAravosFX(params AudioClip[] audioClips)
    {
        int randomIndex = Random.Range(0, audioClips.Length); //I don't do (length - 1) beacuse the second parameter is not included
        AravosSFX.clip = audioClips[randomIndex];
        AravosSFX.volume = 0.2f * AudioManager.volumeMultiplier;
        AravosSFX.Play();
    }
}
