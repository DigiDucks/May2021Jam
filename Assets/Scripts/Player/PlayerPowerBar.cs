using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPowerBar : MonoBehaviour
{
    Slider powerSlider;
    private void Start()
    {
        powerSlider = GetComponent<Slider>();
    }
    public void SetPowerLevel(float power)
    {
        if(powerSlider)
        powerSlider.value = power;
    }
}
