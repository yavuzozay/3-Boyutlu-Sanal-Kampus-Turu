using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public enum States
{
    Player,Car
}
public class GameState : MonoSingleton<GameState>
{
  
   
    public States curState;
    private void Awake()
    {
        curState = States.Car;
    }
    private void Update()
    {
        CheckCamera();
    }
    void CheckCamera()
    {
      /*  string statesString = curState.ToString();
        switch(statesString)
        {
            case "Player":  { virtualCam.LookAt = playerLookAt; } break;
            case "Car":  { virtualCam.LookAt = carLookAt; } break;
            default: break;
        }*/
    }

}
