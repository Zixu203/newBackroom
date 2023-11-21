using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void loadScene(){
        SaveLoader.Load();
        SaveLoader.setLastStorySceneTime(0);
        SaveLoader.setStorySceneRecordTextIndex(0);
        SceneManager.LoadScene("StoryScene");
    }

    public void exitGame(){
        Application.Quit();
    }

}
