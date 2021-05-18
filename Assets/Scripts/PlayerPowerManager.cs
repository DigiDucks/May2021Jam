using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerManager : MonoBehaviour
{
    [SerializeField]
    float powerLevel = 5.0f;
    [SerializeField]
    float maxPower = 10.0f;

    PlayerPowerBar powerBar;
    // Start is called before the first frame update
    void Start()
    {
        powerBar = FindObjectOfType<PlayerPowerBar>();
        powerBar.SetPowerLevel(powerLevel / maxPower);
    }


    public void AddPower(float power)
    {
        powerLevel += power;
        powerLevel = Mathf.Clamp(powerLevel, 0.0f, maxPower);
        powerBar.SetPowerLevel(powerLevel / maxPower);
    }

    public float CheckPower()
    {
        return powerLevel;
    }
}
