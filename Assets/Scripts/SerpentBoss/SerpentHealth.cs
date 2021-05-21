using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerpentHealth : MonoBehaviour
{
    SerpentHitBox[] health;
    // Start is called before the first frame update
    void Start()
    {
        health = FindObjectsOfType<SerpentHitBox>();
    }

    public void HealthCheck()
    {
        foreach(SerpentHitBox box in health)
        {
            if (!box.hit)
                return;
        }
        GameManager.instance.OpenWin();
    }
}
