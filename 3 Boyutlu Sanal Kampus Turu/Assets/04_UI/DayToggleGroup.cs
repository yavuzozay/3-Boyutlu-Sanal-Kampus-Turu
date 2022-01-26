using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayToggleGroup : MonoBehaviour
{
   // ToggleGroup group;

    Toggle morningTgl;
    Toggle nightTgl;

    private void Awake()
    {
        morningTgl = transform.GetChild(0).gameObject.GetComponent<Toggle>();
        nightTgl = transform.GetChild(1).gameObject.GetComponent<Toggle>();
    }
   
    private void Start()
    {
        morningTgl.onValueChanged.AddListener(delegate {
            MorningToggle(morningTgl);
        });
        nightTgl.onValueChanged.AddListener(delegate {
            NightToggle(nightTgl);
        });
        MorningToggle(morningTgl);
       
    }
  
    void MorningToggle(Toggle change)
    {
        LightingManager.Instance.SetCycle(Cycle.Morning);
    }
    void NightToggle(Toggle change)
    {
        LightingManager.Instance.SetCycle(Cycle.Night);
    }


}
