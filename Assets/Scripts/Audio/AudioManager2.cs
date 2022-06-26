using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager2 : PersistentSingleton<AudioManager2>
{
   
    [SerializeField] AudioSource sFXPlayer;
    [SerializeField] AudioSource BGlayer;

    public void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Audio Manager");

        if (player) { 
         Destroy(player);
        }
    }


    //Used for UI SFX
    public void PlaySFX(AudioData audioData)
    {
        sFXPlayer.PlayOneShot(audioData.audioClip, audioData.volume);
    }

    public void PlayBG(AudioData audioData)
    {
        BGlayer.PlayOneShot(audioData.audioClip, audioData.volume);
    }
}
