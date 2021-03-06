﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioClip[] sounds;
    public AudioSource[] channels;

    public static SoundManager instance;

    void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }


        channels = new AudioSource[sounds.Length];
        for (int i = 0; i < channels.Length; i++)
        {
            channels[i] = gameObject.AddComponent<AudioSource>();
            channels[i].clip = sounds[i];
        }

    }

    public void Play(SoundID id, bool loop = false, float volume = 1, float pitch = 1)
    {
        channels[(int)id].Play();
        channels[(int)id].loop = loop;
        channels[(int)id].volume = volume;
        channels[(int)id].pitch = pitch;


    }

    public void StopAll()
    {
        for (int i = 0; i < channels.Length; i++)
        {
            channels[i].Stop();
        }
    }

    public void Stop(SoundID id)
    {
        channels[(int)id].Stop();
    }

    public void Pause(SoundID id)
    {
        channels[(int)id].Pause();
    }

    public void Resume(SoundID id)
    {
        channels[(int)id].UnPause();
    }

    public void ToggleMute(SoundID id)
    {
        channels[(int)id].mute = !channels[(int)id].mute;
    }
}

public enum SoundID
{
    MUSIC_LEVEL1,
    PLAYER_GUN,
    ENEMY_ENERGY,
    ENEMY_SHOT,
    ENEMY_MISSILE,
    LOW_HP,
    EXPLOSION,
    INTRO_SB,
    MUSIC_LEVEL1_BOSS,
    MUSIC_LEVEL2,
    MUSIC_LEVEL2_BOSS,
    MAINMENU,
    CUTSCENE
}