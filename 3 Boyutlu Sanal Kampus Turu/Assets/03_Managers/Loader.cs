using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader 
{
  
public static void LoadGameScene()
    {
     
        SceneManager.LoadScene(1);
    }
    public static void LoadLakeScene()
    {
        SceneManager.LoadScene(2);
    }
    public static void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public static void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

   
}
