using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInteract : MonoBehaviour,IInteractable
{
    private float maxRange = 5f;
    public float MaxRange { get { return maxRange; } }
     CarController thisCarController;
    private GameObject thisCar;
    private Transform lookAt, pos;
    
    private void Awake()
    {
        thisCar = transform.parent.gameObject;
        thisCarController = thisCar.GetComponent<CarController>();
        lookAt= thisCar.transform.GetChild(3);
        pos = thisCar.transform;
    }
    public void OnEndHover()
    {
     
    }

    public void OnInteract()
    {
        CameraController.Instance.CarLookAt = lookAt;
        CameraController.Instance.CarPos = pos;
        GameState.Instance.curState = States.Car;
        //thisCarController = GetComponent<CarController>();


        thisCarController.isInteractedThis = true;
    }

    public void OnStartHover()
    {
      
    }


}
