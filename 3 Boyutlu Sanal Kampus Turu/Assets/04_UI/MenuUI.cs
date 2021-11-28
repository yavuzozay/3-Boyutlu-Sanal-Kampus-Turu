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
    private Image panelBGImage;

    private void Awake()
    {
        panelBGImage = panel.GetComponent<Image>();
    }
    private void Start()
    {
        dropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged(dropdown);
        });
        panelBGImage.sprite = bgImage;

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
}
