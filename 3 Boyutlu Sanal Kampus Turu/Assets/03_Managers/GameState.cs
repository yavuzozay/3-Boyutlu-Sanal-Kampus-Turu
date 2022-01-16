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
    private CameraController cameraController;
    private GameObject player;
    [SerializeField]private Transform playerCarPos;
    public States curState=States.Player;
    private void Awake()
    {
        base.Awake();
        player = GameObject.FindGameObjectWithTag("Player");
        cameraController = Camera.main.transform.parent.transform.GetChild(0).GetComponent<CameraController>();

    }
    private void Update()
    {
     
        CheckState();
    }
   void CheckState()
    {
        if (GameState.Instance.curState == States.Player)
        {
            player.SetActive(true);
            
        }
        else
        {
            if(playerCarPos!=null)
            {
                player.transform.position = cameraController.CarPos.position - playerCarPos.right*2  ;
                player.SetActive(false);

            }


        }
    }
   

}
