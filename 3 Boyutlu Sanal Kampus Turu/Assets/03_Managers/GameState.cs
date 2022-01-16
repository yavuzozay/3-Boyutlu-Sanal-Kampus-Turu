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

    private GameObject player;
    [SerializeField]private Transform playerCarPos;
    public States curState=States.Player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");

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
                player.transform.position = CameraController.Instance.CarPos.position - playerCarPos.right*2
                    ;
                player.SetActive(false);

            }


        }
    }
   

}
