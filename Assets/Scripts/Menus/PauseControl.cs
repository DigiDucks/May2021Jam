using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseControl : MonoBehaviour
{
    public static bool gameIsPaused;

    // Start is called before the first frame update
    void Start()
    {
        gameIsPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        // Stops time and audio
        Time.timeScale = 0;
        gameIsPaused = true;
        AudioListener.pause = true;
    }

    public void Resume()
    {
        // Resumes time and audio
        Time.timeScale = 1;
        gameIsPaused = false;
        AudioListener.pause = false;
    }

    protected IEnumerator ChangeSceneButtonClick(int index, AudioSource source, AudioClip audioClip, float volume)
    {
        float waitTime = 0f;    // Coroutine length

        // If an audio component exists
        if (source)
        {
            // Play sound
            source.PlayOneShot(audioClip, volume);

            // Set coroutine length
            waitTime = audioClip.length;
        }

        // If there is sound, wait for it to finish
        yield return new WaitForSecondsRealtime(waitTime);

        // Move to next scene
        SceneManager.LoadScene(index);

        // Turn the time/audio back on
        Resume();
    }
}
