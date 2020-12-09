using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    private AudioSource[] sounds;
    public AudioSource destroying, gameover, gem;

    private void Awake()
    {
        sounds = gameObject.GetComponents<AudioSource>();
        destroying = sounds[0];
        gameover = sounds[1];
        gem = sounds[2];
    }
}
