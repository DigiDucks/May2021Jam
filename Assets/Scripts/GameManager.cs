using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] GameObject loseCanvas;


    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            LoadLevel(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            LoadLevel(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            LoadLevel(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            LoadLevel(4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            LoadLevel(5);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            LoadLevel(6);
        }

        PlayerLife life = FindObjectOfType<PlayerLife>();
        if(life)
        {
            if(life.PlayerGetLife()<= 0)
            {
                LoseScreenBehavior audio1 = FindObjectOfType<LoseScreenBehavior>();
                audio1.Lose();
                
            }
        }
    }

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level); 
    }

    public void OpenWin()
    {
        WinScreenBehavior audio2 = FindObjectOfType<WinScreenBehavior>();
        audio2.Win();
    }
}
