using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void loadScene(){
        SceneManager.LoadScene("StoryScene");
    }

    public void exitGame(){
        Application.Quit();
    }

}
