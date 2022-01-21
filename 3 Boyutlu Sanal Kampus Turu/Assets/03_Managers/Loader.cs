using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    public static async void LoadScene(int index, GameObject loadingScreen)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);
        Slider slider = loadingScreen.transform.GetChild(1).gameObject.GetComponent<Slider>();
        Text valueText = slider.transform.GetChild(2).gameObject.GetComponent<Text>();
        operation.allowSceneActivation = false;

        do
        {
            await Task.Delay(100);
            float value = Mathf.Clamp01(operation.progress / .9f);
            slider.value = value;
            valueText.text = value.ToString();


        }
        while (operation.progress < .9f);
        operation.allowSceneActivation = true;

    }
    public static IEnumerator LoadAsynchrounously(int index, GameObject loadingScreen)
    {
        loadingScreen.SetActive(true);
        Image img = loadingScreen.transform.GetChild(0).gameObject.GetComponent<Image>();
        Slider slider = loadingScreen.transform.GetChild(1).gameObject.GetComponent<Slider>();
        Text text = slider.transform.GetChild(2).gameObject.GetComponent<Text>();
        Text text2 = loadingScreen.transform.GetChild(3).gameObject.GetComponent<Text>();
        string loadText = ". ";
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);
        Animator fadeanim=loadingScreen.GetComponent<Animator>() ;
        // async.allowSceneActivation = false;

        //slider.value = 0;
        // float progress = 0;
        //async.allowSceneActivation = false;
        int loadingCount = 0;
        while (!operation.isDone)
        {
            if (loadingCount > 3) loadingCount = 0;
            loadingCount++;
                float progress = (operation.progress/0.9F);
            //Debug.Log(operation.priority);
            Debug.Log(progress);
                  slider.value = progress;
                text.text = progress * 100 + "%100";
            //Debug.Log(text2);
            for (int i = 0; i < loadingCount; i++)
            {
                text2.text += loadText;

            }
            if (progress == 1)
            {
                fadeanim.SetTrigger("fade");
                yield return new WaitForSeconds(1f);
            }
            yield return new WaitForSeconds(.1f);

        }
    }
}
