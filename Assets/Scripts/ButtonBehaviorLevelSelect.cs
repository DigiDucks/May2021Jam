using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviorLevelSelect : MonoBehaviour
{
    // Level 1
    public void Level1()
    {
        SceneManager.LoadScene("Level1");
    }

    // Level 2
    public void Level2()
    {
        SceneManager.LoadScene("Level2");
    }

    // Level 3
    public void Level3()
    {
        SceneManager.LoadScene("Boss-1");
    }

}
