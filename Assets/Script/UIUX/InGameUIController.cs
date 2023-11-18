using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[Serializable]
public class InGameUIController
{
    public Image settingMenu;
    public Button settingBtn;
    public Button continueBtn;
    public Button playerOpBtn;
    public Button exitBtn;
    public Button redoBtn;
    public Image playerContorlUI;
    public bool haveWindow;

    public void init(){
        settingBtn = GameObject.Find("UI").transform.GetChild(0).GetComponent<UnityEngine.UI.Button>();
        settingBtn.onClick.AddListener(openSetting);

        settingMenu = GameObject.Find("SettingMenu").transform.GetChild(0).GetComponent<UnityEngine.UI.Image>();

        continueBtn = settingMenu.transform.GetChild(0).GetComponent<UnityEngine.UI.Button>();
        playerOpBtn = settingMenu.transform.GetChild(1).GetComponent<UnityEngine.UI.Button>();
        exitBtn = settingMenu.transform.GetChild(2).GetComponent<UnityEngine.UI.Button>();

        continueBtn.onClick.AddListener(openSetting);
        playerOpBtn.onClick.AddListener(openPlayOp);
        exitBtn.onClick.AddListener(goStartMenu);

        playerContorlUI = GameObject.Find("PlayerControlUI").transform.GetChild(0).GetComponent<UnityEngine.UI.Image>();
        redoBtn = playerContorlUI.transform.GetChild(1).GetComponent<UnityEngine.UI.Button>();

        redoBtn.onClick.AddListener(redoFun);
        haveWindow = false;
    }
    public void openSetting(){
        if(haveWindow) return;
        if(settingMenu.gameObject.activeSelf == true){
            settingMenu.gameObject.SetActive(false);
            settingBtn.gameObject.SetActive(true);
        } 
        else{
            settingMenu.gameObject.SetActive(true);
            settingBtn.gameObject.SetActive(false);
        } 
    }

    public void openPlayOp(){
        haveWindow = true;
        playerContorlUI.gameObject.SetActive(true);
        settingMenu.gameObject.SetActive(false);
    }
    
    public void goStartMenu(){
        SceneManager.LoadScene("StartMenu");
    }
    public void redoFun(){
        haveWindow = false;
        playerContorlUI.gameObject.SetActive(false);
        settingMenu.gameObject.SetActive(true);
    }
}
