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
    [SerializeField] private Button controlsButton;
    [SerializeField] private Button closeControlBtn;

    private bool isControlPanelActive = false;


    private Image panelBGImage;

    private void Awake()
    {
        panelBGImage = panel.GetComponent<Image>();
    }
    private void Start()
    {
        controlsPanel.SetActive(isControlPanelActive);

        dropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged(dropdown);
        });
        panelBGImage.sprite = bgImage;
        controlsButton.onClick.AddListener(SetControlPanel);
        closeControlBtn.onClick.AddListener(CloseControlPanel);


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
    void DropdownValueChanged(Dropdown change)
    {
        selectedScene = change.value+1;
        switch(selectedScene)
        {
            case 1: { panelBGImage.sprite = bgImage; } break;
            case 2: { panelBGImage.sprite = bgImage2; } break;
            default: break;
        }
      
    }
    public  void StartButton()
    {
        Loader.Instance.LoadScene(selectedScene);
    }
    public void Quit()
    {
        Application.Quit();        
    }
}
