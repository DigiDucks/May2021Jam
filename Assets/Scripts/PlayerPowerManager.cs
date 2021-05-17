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
    }

    // Update is called once per frame
    void Update()
    {
        powerBar.SetPowerLevel(powerLevel/maxPower);
    }

    public void AddPower(float power)
    {
        powerLevel += power;
    }

    public float CheckPower()
    {
        return powerLevel;
    }
}
