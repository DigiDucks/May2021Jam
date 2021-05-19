using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviorMainMenu : MonoBehaviour
{
    private AudioSource source;
    private AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        // Get the button click audio
        source = GetComponent<AudioSource>();
        clip = source.clip;
    }

    // Play Button
    public void OnPlayButtonPress()
    {
        // Outsource sound logic
        StartCoroutine("PlayButton");
    }

    // Quit Button
    public void OnQuitButtonPress()
    {
        // Outsource sound logic
        StartCoroutine("QuitButton");
    }

    IEnumerator PlayButton()
    {
        // Play sound
        source.Play();
        yield return new WaitForSeconds(clip.length);
        SceneManager.LoadScene("LevelSelect");
    }

    IEnumerator QuitButton()
    {
        // Play sound
        source.Play();
        yield return new WaitForSeconds(clip.length);
        Debug.Log("Exit Game");
        Application.Quit();
    }

}
