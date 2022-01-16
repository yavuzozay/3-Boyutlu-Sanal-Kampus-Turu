using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowy : WeatherData
{
    public override void ManageWeather()
    {
        Debug.Log("Karlý günden selamlar !");
        RenderSettings.skybox = skyboxMat;

    }
}
