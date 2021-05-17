using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviorMainMenu : MonoBehaviour
{
    // Play Button
    public void OnPlayButtonPress()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    // Quit Button
    public void OnQuitButtonPress()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }

}
