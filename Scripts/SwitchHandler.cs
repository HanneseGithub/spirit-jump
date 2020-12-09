using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using DG.Tweening;
using System;
public class SwitchHandler : MonoBehaviour
{
    private int soundSwitchState, musicSwitchState;
    public GameObject switchBtn;
    public AudioMixerSnapshot normal;
    public AudioMixerSnapshot mute;

    private void Start()
    {
        // Save current state of the volume into a variable.
        soundSwitchState = PlayerPrefs.GetInt("SoundSwitchState", 1);
        musicSwitchState = PlayerPrefs.GetInt("MusicSwitchState", 1);

        // Make sure that buttons don't get tangled.
        if (gameObject.CompareTag("MusicBtn"))
        {
            if (musicSwitchState == -1)
            {
                switchBtn.transform.DOLocalMoveX(-switchBtn.transform.localPosition.x, 0.2f);
                mute.TransitionTo(0.5f);
            }
        }

        if (gameObject.CompareTag("SoundBtn"))
        {
            if (soundSwitchState == -1)
            {
                switchBtn.transform.DOLocalMoveX(-switchBtn.transform.localPosition.x, 0.2f);
                mute.TransitionTo(0.5f);
            }
        }
    }

    public void OnMusicButtonClicked()
    {
        // Move the button (forced).
        switchBtn.transform.DOLocalMoveX(-switchBtn.transform.localPosition.x, 0.2f);

        // Save the state that the button was CALLED FROM.
        musicSwitchState = PlayerPrefs.GetInt("MusicSwitchState", 1);

        // Save new state and set volume.
        if (musicSwitchState == 1)
        {
            PlayerPrefs.SetInt("MusicSwitchState", -1);
            mute.TransitionTo(0.5f);
        }
        else
        {
            PlayerPrefs.SetInt("MusicSwitchState", 1);
            normal.TransitionTo(0.5f);
        }
    }

    public void OnSoundButtonClicked()
    {
        switchBtn.transform.DOLocalMoveX(-switchBtn.transform.localPosition.x, 0.2f);

        soundSwitchState = PlayerPrefs.GetInt("SoundSwitchState", 1);

        if (soundSwitchState == 1)
        {
            PlayerPrefs.SetInt("SoundSwitchState", -1);
            mute.TransitionTo(0.5f);
        }
        else
        {
            PlayerPrefs.SetInt("SoundSwitchState", 1);
            normal.TransitionTo(0.5f);
        }
    }
}
