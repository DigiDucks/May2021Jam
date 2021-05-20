using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwordSounds : MonoBehaviour
{
    public AudioSource sourceSword;     // For one-shot sound effects
    public AudioSource sourcePlayer;    // For long-term charging sounds

    // Just sounds for the sword by itself
    public AudioClip swingRegular;
    public AudioClip swingCharged;

    [SerializeField] float volume = 0.5f;

    private bool isCharging;

    // Start is called before the first frame update
    void Start()
    {
        isCharging = false;
    }

    // Public methods for playing the sound effects
    public void PlaySwingRegular()
    {
        sourceSword.PlayOneShot(swingRegular, volume);
    }

    public void PlaySwingCharged()
    {
        sourceSword.PlayOneShot(swingCharged, volume);
    }

    public void PlayChargeUp()
    {
        if (!isCharging)
        {
            isCharging = true;
            sourcePlayer.Play();
        }
    }

    public void StopChargeUp()
    {
        isCharging = false;
        sourcePlayer.Stop();
    }
}
