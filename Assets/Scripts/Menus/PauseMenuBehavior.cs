using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuBehavior : MonoBehaviour
{
    public static bool gameIsPaused;

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
    
    // Pause Button
    public void PauseGame()
    {
        // Pauses audio in general
        Time.timeScale = 0;
        gameIsPaused = true;
        AudioListener.pause = true;

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
        Time.timeScale = 1;
        gameIsPaused = false;
        AudioListener.pause = false;

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
        // Outsource sound logic
        StartCoroutine("ReturnToMenu");
    }

    IEnumerator ReturnToMenu()
    {
        // Play sound
        source.PlayOneShot(clip, volume);

        // WaitForSecondsRealtime ignores the timescale/pause
        yield return new WaitForSecondsRealtime(clip.length);

        // Load next scene
        SceneManager.LoadScene("MainMenu");

        // Turn the audio back on
        Time.timeScale = 1;
        gameIsPaused = false;
        AudioListener.pause = false;
    }
}
