using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public enum States
{
    Player,Car
}
public class GameState : MonoSingleton<GameState>
{
   
    public States curState;
    private void Awake()
    {
        base.Awake();
        curState = States.Player;
    }
    private void OnSceneLoaded(Scene scene,LoadSceneMode mode)
    {
        if (scene.buildIndex == 0)//Menüdeyken playerın görünmesin.
        {
            curState = States.Player;
            PlayerData.Instance.gameObject.SetActive(true);
            PlayerData.Instance.GetComponent<CharacterController>().enabled = false;


        }
     
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded+=OnSceneLoaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded-=OnSceneLoaded;

    }

}
