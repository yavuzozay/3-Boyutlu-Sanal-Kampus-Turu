using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoSingleton<CameraController>
{
    CinemachineVirtualCamera virtualCam;
   [SerializeField] private Transform playerLookAt,playerPos;
   private Transform carLookAt,carPos;
    public Transform CarLookAt
    {
        set { carLookAt = value; }
    }
    public Transform CarPos
    {
        get { return carPos; }
        set { carPos = value; }
    }
   
  
    private void Awake()
    {
        virtualCam = GetComponent<CinemachineVirtualCamera>();

    }
    void Update()
    {
        CheckCamera();   
    }
    void CheckCamera()
    {
        string statesString =GameState.Instance.curState.ToString();
        switch (statesString)
        {
            case "Player": { 
                    virtualCam.LookAt = playerLookAt;
                    virtualCam.Follow = playerPos;
                } break;
            case "Car": {
                    virtualCam.LookAt = carLookAt;
                    virtualCam.Follow = carPos;
                } break;
            default: break;
        }
    }
}
