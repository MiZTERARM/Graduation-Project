using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundButtonPlay : MonoBehaviour
{
    public AudioClip[] soundFile;
    public AudioSource soundButton;
    private int soundNumber;

    public void PlayButton()
    {
        soundButton.PlayOneShot(soundFile[soundNumber]);
    }
}
