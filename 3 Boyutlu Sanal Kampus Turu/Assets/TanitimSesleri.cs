using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TanitimSesleri : MonoBehaviour,IInteractable
{
    [SerializeField] AudioClip clip;

    private float maxRange = 5f;
    public float MaxRange { get { return maxRange; } }

    public void OnEndHover()
    {
       
    }

    public void OnInteract()
    {
        Debug.Log("E");

    }

    public void OnStartHover()
    {
        Debug.Log("E");
    }
}
