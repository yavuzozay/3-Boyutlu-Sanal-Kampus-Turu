using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggeredSound : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer== 7)
        {
            Debug.Log("a");
        }
    }
}
