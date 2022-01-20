using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    CinemachineVirtualCamera virtualCam;
    private Transform playerLookAt,playerPos;
   private Transform carLookAt,carPos;
    private GameObject player;
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
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerLookAt = player.transform.GetChild(2);
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
                    if (playerLookAt == null || player == null)
                    {
                        player = GameObject.FindGameObjectWithTag("Player");
                        playerLookAt = player.transform.GetChild(2);
                    }
                    virtualCam.LookAt = playerLookAt.transform;
                    virtualCam.Follow = player.transform;
                } break;
            case "Car": {
                    virtualCam.LookAt = carLookAt;
                    virtualCam.Follow = carPos;
                } break;
            default: break;
        }
    }
}
