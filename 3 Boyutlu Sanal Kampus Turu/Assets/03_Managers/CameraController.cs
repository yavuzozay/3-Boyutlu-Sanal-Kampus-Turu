using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    CinemachineVirtualCamera virtualCam;
    [SerializeField] Transform playerLookAt,playerPos;
    [SerializeField] Transform carLookAt,carPos;
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
