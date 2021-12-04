using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoSingleton<Loader>
{
public void LoadGameScene()
    {
     
        SceneManager.LoadScene(1);
    }
    public void LoadLakeScene()
    {
        SceneManager.LoadScene(2);
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
