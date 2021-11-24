using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInteract : MonoBehaviour,IInteractable
{
    private float maxRange = 5f;
    public float MaxRange { get { return maxRange; } }

    public void OnEndHover()
    {
     
    }

    public void OnInteract()
    {
        GameState.Instance.curState = States.Car;
    }

    public void OnStartHover()
    {
      
    }


}
