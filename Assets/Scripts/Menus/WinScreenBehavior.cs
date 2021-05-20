using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreenBehavior : PauseControl
{
    private GameObject winPanel;
    private string nextScene;

    private AudioSource source;
    private AudioClip clip;

    [SerializeField] public float volume = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        // The LoseCanvas and it's children need to be active
        // so that the GameObject.Find() function works
        winPanel = GameObject.Find("Backdrop");

        // Set initial visibilities of UI elements
        winPanel.SetActive(false);

        // Set nextScene to current scene for debugging purposes
        nextScene = SceneManager.GetActiveScene().name;

        // Get the button click audio
        source = GetComponent<AudioSource>();
        if (source)
            clip = source.clip;

        // Make sure it plays even when the game is paused
        source.ignoreListenerPause = true;
    }

    public void Win(string sceneName)
    {
        // Pauses time/audio in general
        Pause();

        // Set the next scene for continuing players
        nextScene = sceneName;

        // Turn on lose screen UI elements
        winPanel.SetActive(true);
    }

    // Resume Button
    public void Continue()
    {
        // Gets the current scene and restarts it
        StartCoroutine(ChangeSceneButtonClick(nextScene, source, clip, volume));
    }

    // Quit Button
    public void QuitGame()
    {
        // Return to main menu
        StartCoroutine(ChangeSceneButtonClick("MainMenu", source, clip, volume));
    }

}
