using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  abstract class WeatherData :MonoBehaviour
{
    [SerializeField] private  AudioClip _clip;
    [SerializeField] protected Material skyboxMat;
    [SerializeField][Range (0,1)]private float rotSpeed=1;
    public AudioClip clip
    {
        get { return _clip; }
       
    }
    private void Awake()
    {
        WeatherManager.Instance.SetSkyboxRotSpeed=rotSpeed; 
    }
    public abstract void ManageWeather();
    private void LateUpdate()
    {
    }
    private void OnDestroy()
    {
        SoundManager.Instance.PlayBGMusic(null);
    }




}
