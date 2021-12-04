using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private Dropdown dropdown;
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


    private bool isControlPanelActive = false;


    private Image panelBGImage;

    private void Awake()
    {
        panelBGImage = panel.GetComponent<Image>();
    }
    private void Start()
    {
        controlsPanel.SetActive(isControlPanelActive);
        settings.SetActive(false);


        dropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged(dropdown);
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
        Loader.Instance.LoadScene(selectedScene);
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
