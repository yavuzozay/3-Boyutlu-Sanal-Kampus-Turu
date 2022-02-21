using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    private GameObject lightObj;

    private void Awake()
    {
        lightObj = transform.GetChild(0).gameObject;
    }

    private void Start()
    {
        if(lightObj!= null)
        {
            if (LightingManager.Instance.GetCycle() == Cycle.Morning)
            {
                lightObj.SetActive(false);
            }
            else
            {
                lightObj.SetActive(true);
            }
        }
        else
        {
            Debug.Log("Iþýk bulunamadý.");
        }
      
    }

}
