using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain :WeatherData
{
    public override void ManageWeather()
    {
     


        if (LightingManager.Instance.GetCycle() == Cycle.Morning)
        {
            Debug.Log("Yaðmurlu günden selamlar !");
            RenderSettings.skybox = skyboxMat;
            LightingManager.Instance.DefaultMorningMode();

        }
        else
        {
            LightingManager.Instance.DefaultNightMode();
        }
       
    }
}
