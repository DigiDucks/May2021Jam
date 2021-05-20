using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuBehavior : PauseControl
{
    private GameObject pauseButton;
    private GameObject pausePanel;

    private AudioSource source;
    private AudioClip clip;

    [SerializeField] public float volume = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        // The PauseCanvas and it's children need to be active
        // so that the GameObject.Find() function works
        pauseButton = GameObject.Find("Pause Button");
        pausePanel = GameObject.Find("Backdrop");

        // Set initial visibilities of UI elements
        pauseButton.SetActive(true);
        pausePanel.SetActive(false);

        // Get the button click audio
        source = GetComponent<AudioSource>();
        if (source)
            clip = source.clip;

        // Make sure it plays even when the game is paused
        source.ignoreListenerPause = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!gameIsPaused)
            {
                PauseGame();
            }
        }
    }

    // Pause Button
    public void PauseGame()
    {
        // Pause time/audio in general
        Pause();

        // Play sound if an audio component exists
        if (source)
        {
            source.PlayOneShot(clip, volume);
        }

        // Swap visible UI elements
        pauseButton.SetActive(false);
        pausePanel.SetActive(true);
    }

    // Resume Button
    public void ResumeGame()
    {
        // Resume time/audio in general
        Resume();

        // Play sound if an audio component exists
        if (source)
        {
            source.PlayOneShot(clip, volume);
        }

        // Swap visible UI elements
        pauseButton.SetActive(true);
        pausePanel.SetActive(false);
    }

    // Quit Button
    public void QuitGame()
    {
        // Return to main menu
        StartCoroutine(ChangeSceneButtonClick(0, source, clip, volume));
    }

}
