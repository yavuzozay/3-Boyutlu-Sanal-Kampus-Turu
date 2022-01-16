using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sunny : WeatherData
{
    public override void ManageWeather()
    {
        Debug.Log("Güneþli günden selamlar !");
       // GameObject.FindGameObjectWithTag("Player").transform.position += new Vector3(0, 100, 0);
        RenderSettings.skybox = skyboxMat;

    }
}
