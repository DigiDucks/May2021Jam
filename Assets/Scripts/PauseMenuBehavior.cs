using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuBehavior : MonoBehaviour
{
    public static bool gameIsPaused;

    private GameObject pauseButton;
    private GameObject pausePanel;

    // Start is called before the first frame update
    void Start()
    {
        // The PauseCanvas and it's children need to be active
        // so that the GameObject.Find() function works
        pauseButton = GameObject.Find("Pause Button");
        pausePanel = GameObject.Find("Backdrop");

        pauseButton.SetActive(true);
        pausePanel.SetActive(false);
    }
    
    // Pause Button
    public void PauseGame()
    {
        Time.timeScale = 0;
        gameIsPaused = true;
        AudioListener.pause = true;

        pauseButton.SetActive(false);
        pausePanel.SetActive(true);
    }

    // Resume Button
    public void ResumeGame()
    {
        Time.timeScale = 1;
        gameIsPaused = false;
        AudioListener.pause = false;

        pauseButton.SetActive(true);
        pausePanel.SetActive(false);
    }

    // Quit Button
    public void QuitGame()
    {
        SceneManager.LoadScene("MainMenu");

        Time.timeScale = 1;
        gameIsPaused = false;
        AudioListener.pause = false;
    }
}
