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
    private CameraController cameraController;
    
    private void Awake()
    {
        thisCar = transform.parent.gameObject;
        thisCarController = thisCar.GetComponent<CarController>();
        lookAt= thisCar.transform.GetChild(3);
        pos = thisCar.transform;
        cameraController = Camera.main.transform.parent.transform.GetChild(0).GetComponent<CameraController>();

    }
    public void OnEndHover()
    {
     
    }

    public void OnInteract()
    {
        cameraController.CarLookAt = lookAt;
        cameraController.CarPos = pos;
        GameState.Instance.curState = States.Car;
        //thisCarController = GetComponent<CarController>();
        thisCarController.isInteractedThis = true;
    }

    public void OnStartHover()
    {
      
    }


}
