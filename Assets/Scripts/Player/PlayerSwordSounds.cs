using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwordSounds : MonoBehaviour
{
    public AudioSource source;

    // Only includes sounds for the sword by itself
    public AudioClip swingRegular;
    public AudioClip swingCharged;

    [SerializeField] public float volume = 0.5f;

    // Public methods for playing the sound effects
    public void PlaySwingRegular()
    {
        source.PlayOneShot(swingRegular, volume);
    }

    public void PlaySwingCharged()
    {
        source.PlayOneShot(swingCharged, volume);
    }
}
