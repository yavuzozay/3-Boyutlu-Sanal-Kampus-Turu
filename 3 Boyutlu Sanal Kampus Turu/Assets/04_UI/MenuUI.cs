using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private Dropdown dropdown;
    [SerializeField] private Dropdown weatherSettingsDD;
    int selectedScene=1;
    [SerializeField] private Sprite bgImage;
    [SerializeField] private Sprite bgImage2;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject controlsPanel;
    [SerializeField] private GameObject settings;
    [SerializeField] private Button controlsButton;
    [SerializeField] private Button closeControlBtn;
    [SerializeField] private Button closeSettingsButton;
     [SerializeField] private Button startBtn, settingsBtn, exitBtn;

     private Slider slider;
    [SerializeField]private GameObject loadingScreen;


    private bool isControlPanelActive = false;


    private Image panelBGImage;

    private void Awake()
    {
        panelBGImage = panel.GetComponent<Image>();
        slider = loadingScreen.transform.GetChild(0).gameObject.GetComponent<Slider>();
    }
    private void Start()
    {
        controlsPanel.SetActive(isControlPanelActive);
        settings.SetActive(false);


        dropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged(dropdown);
        });
        weatherSettingsDD.onValueChanged.AddListener(delegate {
            WeatherSettingsDDChanged(weatherSettingsDD);
        });
        panelBGImage.sprite = bgImage;
        startBtn.onClick.AddListener(StartButton);
        settingsBtn.onClick.AddListener(SettingsButton);
        exitBtn.onClick.AddListener(Quit);
        controlsButton.onClick.AddListener(SetControlPanel);
        closeControlBtn.onClick.AddListener(CloseControlPanel);
        closeSettingsButton.onClick.AddListener(CloseSettings);


    }
    private void CloseControlPanel()
    {
        isControlPanelActive = false;
        controlsPanel.SetActive(isControlPanelActive);
    }
    
    private void SetControlPanel()
    {
        isControlPanelActive = true;
        controlsPanel.SetActive(isControlPanelActive);
    }

    private void CloseSettings()
    {
        settings.SetActive(false);

    }
    private void WeatherSettingsDDChanged(Dropdown dropdown)
    {
        
        switch (dropdown.value)
        {
            case 0: { Debug.Log("Sunny");
        WeatherManager.Instance.SetStates(WeatherStates.Sunny);
                }; break;
            case 1: { Debug.Log("Rainy"); 
        WeatherManager.Instance.SetStates(WeatherStates.Rainy);
                }; break;
            case 2: { Debug.Log("Snowy");
                         WeatherManager.Instance.SetStates(WeatherStates.Snowy);
                         }; break;
            default: break;
        }
    }
    private void DropdownValueChanged(Dropdown change)
    {
        selectedScene = change.value+1;
        switch(selectedScene)
        {
            case 1: { panelBGImage.sprite = bgImage; } break;
            case 2: { panelBGImage.sprite = bgImage2; } break;
            default: break;
        }
      
    }
    private  void StartButton()
    {
        //Loader.LoadScene(selectedScene);
         StartCoroutine(Loader.LoadAsynchrounously(selectedScene, loadingScreen));
     //   Loader.LoadScene(selectedScene, loadingScreen);
    }
    IEnumerator LoadAsynchrounously(int index, GameObject loadingScreen)
    {
   loadingScreen.SetActive(true);
      Slider  slider = loadingScreen.transform.GetChild(1).gameObject.GetComponent<Slider>();
       Text text = slider.transform.GetChild(2).gameObject.GetComponent<Text>();
       AsyncOperation operation = SceneManager.LoadSceneAsync(index);
      // async.allowSceneActivation = false;

       //slider.value = 0;
       float progress = 0;
       //async.allowSceneActivation = false;
       while (!operation.isDone)
       {
           progress = Mathf.Clamp01(operation.progress / .9f) ;
           Debug.Log(operation.progress);
           slider.value = progress;
           text.text = (int)progress*100+ "%100";

       yield return null;
       }
    }
    private void SettingsButton()
    {
        settings.SetActive(true);
    }
    private void Quit()
    {
        Application.Quit();        
    }

  
   
}
