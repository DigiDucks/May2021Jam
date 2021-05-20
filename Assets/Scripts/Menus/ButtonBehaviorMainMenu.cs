using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviorMainMenu : MonoBehaviour
{
    private AudioSource source;
    private AudioClip clip;

    [SerializeField] public float volume = 0.5f;

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

    // Credits Button
    public void OnCreditsButtonPress()
    {
        // Outsource sound logic
        StartCoroutine("CreditsButton");
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
        source.PlayOneShot(clip, volume);
        yield return new WaitForSeconds(clip.length);

        // Next scene
        SceneManager.LoadScene("LevelSelect");
    }

    IEnumerator CreditsButton()
    {
        // Play sound
        source.PlayOneShot(clip, volume);
        yield return new WaitForSeconds(clip.length);

        // Next scene
        SceneManager.LoadScene("Credits");
    }

    IEnumerator QuitButton()
    {
        // Play sound
        source.PlayOneShot(clip, volume);
        yield return new WaitForSeconds(clip.length);

        // Exit application
        Debug.Log("Exit Game");
        Application.Quit();
    }

}
