using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public AudioMixerSnapshot normalMusic, muteMusic, muteSound, normalSound;
    private int soundSwitchState, musicSwitchState;

    private void Awake()
    {
        soundSwitchState = PlayerPrefs.GetInt("SoundSwitchState", 1);
        musicSwitchState = PlayerPrefs.GetInt("MusicSwitchState", 1);
    }

    private void Start()
    {
        // HACKY: Load sound when game starts
        if (soundSwitchState == -1)
        {
            muteSound.TransitionTo(0.5f);
        }
        else if (soundSwitchState == 1)
        {
            normalSound.TransitionTo(0.5f);
        }

        // HACKY: Load music when game starts
        if (musicSwitchState == -1)
        {
            muteMusic.TransitionTo(0.5f);
        }
        else if (musicSwitchState == 1)
        {
            normalMusic.TransitionTo(0.5f);
        }
    }
}
