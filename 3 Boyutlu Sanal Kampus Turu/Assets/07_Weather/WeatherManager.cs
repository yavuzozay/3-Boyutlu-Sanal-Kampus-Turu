using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum WeatherStates
{
    Sunny,Rainy,Snowy
}

public class WeatherManager : MonoSingleton<WeatherManager>
{
    [SerializeField]WeatherStates states=WeatherStates.Rainy;
    [SerializeField] GameObject rain,snow,sunny;
    private float _rotSpeed;
    GameObject player;
    Vector3 spawnpos = new Vector3(0, 0, 0);
    GameObject curWeatherEffect = null;
    //private WeatherData weatherData;
    WeatherData weatherData;

    //Hava durumunu menüde deðiþtir.
    public void SetStates(WeatherStates states)
    {
        this.states = states;
    }
    public float SetSkyboxRotSpeed
    {
        set { this._rotSpeed = value; }
    }
    private void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);

    }
   
    private void Start()
    {
            player = GameObject.FindGameObjectWithTag("Player");

    }
    void ChangeEffectPos(Vector3 pos)
    {
        if (curWeatherEffect != null)
        {
            curWeatherEffect.transform.position = pos;
        }
    }
  
    private void OnSceneLoaded(Scene scene,LoadSceneMode mode)
    {
      //  if(SceneManager.activeSceneChanged(0,1))

        if (scene.buildIndex != 0)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            if (player == null) return;
           
                string statesString =states.ToString();
            switch (statesString)
            {
                case "Sunny":
                    {
                        curWeatherEffect = Instantiate(sunny, spawnpos, Quaternion.identity);

                    }
                    break;
                case "Rainy":
                    {
                        curWeatherEffect = Instantiate(rain, spawnpos, Quaternion.identity);
                     



                    }
                    break;
                case "Snowy":
                    {
                        curWeatherEffect = Instantiate(snow, spawnpos, Quaternion.identity);

                    }
                    break;
                default: break;
            }
            weatherData = curWeatherEffect.GetComponent<WeatherData>();

            if (weatherData != null)
            {
                SoundManager.Instance.PlayBGMusic(weatherData.clip);
                weatherData.ManageWeather();
            }
                   

                    
            }
        }


    private void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * _rotSpeed);
        RenderSettings.skybox.SetFloat("_Ex",.1f);

    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        EventManager.onWeatherEffectPosChanged += ChangeEffectPos;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;

        EventManager.onWeatherEffectPosChanged -= ChangeEffectPos;

    }


}
