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
        if (scene.buildIndex == 0)//Menüdeyken playerýn görünmesin.
        {
            curState = States.Player;
            PlayerData.Instance.gameObject.SetActive(false);


        }
        else
        {
            PlayerData.Instance.gameObject.SetActive(true);
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
