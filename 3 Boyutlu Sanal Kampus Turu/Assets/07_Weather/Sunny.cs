using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sunny : WeatherData
{
    public override void ManageWeather()
    {
        if (LightingManager.Instance.GetCycle() == Cycle.Morning)
        {
            Debug.Log("Ya�murlu g�nden selamlar !");
            RenderSettings.skybox = skyboxMat;
           // LightingManager.Instance.DefaultMorningMode();

        }
        else
        {
            LightingManager.Instance.DefaultNightMode();
        }
    }
}
