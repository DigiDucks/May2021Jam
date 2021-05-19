using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviorLevelSelect : MonoBehaviour
{
    private AudioSource source;
    private AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        // Get the button click audio
        source = GetComponent<AudioSource>();
        if (source)
            clip = source.clip;
    }

    IEnumerator ButtonClick(string scene)
    {
        float waitTime = 0f;    // Coroutine length
        
        // If an audio component exists
        if (source)
        {
            // Play sound
            source.Play();

            // Set coroutine length
            waitTime = clip.length;
        }

        // If there is sound, wait for it to finish
        yield return new WaitForSeconds(waitTime);

        // Move to next scene
        SceneManager.LoadScene(scene);
    }

    // Level 1
    public void Level1()
    {
        StartCoroutine(ButtonClick("Level1"));
    }

    // Level 2
    public void Level2()
    {
        StartCoroutine(ButtonClick("Level2"));
    }

    // Level 3
    public void Level3()
    {
        StartCoroutine(ButtonClick("Boss-1"));
    }

    // Main Menu
    public void MainMenu()
    {
        StartCoroutine(ButtonClick("MainMenu"));
    }

}
