using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherEffectsPosController : MonoBehaviour
{
    [SerializeField] private Vector3 offset = new Vector3(0, 0, 0);
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer==7)
        {
           EventManager.Fire_onWeatherEffectPosChanged(transform.position+offset);
        }
    }
}
