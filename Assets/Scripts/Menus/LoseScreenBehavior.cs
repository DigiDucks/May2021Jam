using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScreenBehavior : PauseControl
{
    private GameObject losePanel;

    private AudioSource source;
    private AudioClip clip;

    [SerializeField] public float volume = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        // The LoseCanvas and it's children need to be active
        // so that the GameObject.Find() function works
        losePanel = GameObject.Find("Backdrop1");

        // Set initial visibilities of UI elements
        losePanel.SetActive(false);

        // Get the button click audio
        source = GetComponent<AudioSource>();
        if (source)
            clip = source.clip;

        // Make sure it plays even when the game is paused
        source.ignoreListenerPause = true;
    }

    public void Lose()
    {
        // Pauses time/audio in general
        Pause();

        // Turn on lose screen UI elements
        losePanel.SetActive(true);
    }

    // Resume Button
    public void RestartGame()
    {
        // Gets the current scene and restarts it
        StartCoroutine(ChangeSceneButtonClick(SceneManager.GetActiveScene().buildIndex, source, clip, volume));
        // The LoseCanvas and it's children need to be active
        // so that the GameObject.Find() function works
        losePanel = GameObject.Find("Backdrop1");

        // Set initial visibilities of UI elements
        losePanel.SetActive(false);
    }

    // Quit Button
    public void QuitGame()
    {
        // Return to main menu
        StartCoroutine(ChangeSceneButtonClick(0, source, clip, volume));
    }

}
