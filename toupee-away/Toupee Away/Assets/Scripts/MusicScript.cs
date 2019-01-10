using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class MusicScript : MonoBehaviour
{

    AudioSource musicPlayer;
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        musicPlayer = gameObject.GetComponent<AudioSource>();
        PlayMusic();
    }

    public void PlayMusic()
    {
        musicPlayer.Play();
    }

    public void MuteMusic()
    {
        musicPlayer.mute = true;
    }

    public void UnmuteMusic()
    {
        musicPlayer.mute = false;
    }

    public bool IsMuted()
    {
        if(musicPlayer.mute == true)
        {
            return true;
        }
        else if (musicPlayer.mute == false)
        {
            return false;
        }
        else
        {
            return false;
        }
    }

}
