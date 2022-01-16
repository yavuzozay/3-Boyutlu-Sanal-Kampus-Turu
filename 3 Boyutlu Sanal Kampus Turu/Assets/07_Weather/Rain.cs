using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain :WeatherData
{
    public override void ManageWeather()
    {
        Debug.Log("Yaðmurlu günden selamlar !");
        RenderSettings.skybox = skyboxMat;
    }
}
