using System;
using System.Collections;
using System.Collections.Generic;
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
	public List<Image> knapsackItems;
	public List<string> knapsackItemName;
	public Image knapsackUI;
	public Dictionary<string, string> itemToImg;
	public int itemsCount=0;

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

		itemToImg = new Dictionary<string, string>() {
            {"key",  "key" },
			{"cureBag", "cureBag" },
        };

        knapsackUI = GameObject.Find("Knapsack").transform.GetChild(0).GetComponent<UnityEngine.UI.Image>();
		knapsackItems = new List<Image>();
		knapsackItemName = new List<string>();

		for (int i=0;i<5;++i)
        {
			knapsackItems.Add(knapsackUI.transform.GetChild(i).GetComponent<UnityEngine.UI.Image>());
			knapsackItemName.Add("None");

		}
		

		redoBtn.onClick.AddListener(redoFun);
		haveWindow = false;
	}
	public void pushInKnapsack(string itemName)
    {
		knapsackItems[itemsCount].sprite = Resources.Load<Sprite>(itemToImg[itemName]);
		knapsackItemName[itemsCount] = itemName;
		itemsCount++;
    }
	public void popOutKnapsack(string itemName)
    {
		int i = 0;
		for(i=0;i<4;++i)
        {
			if (knapsackItemName[i] == itemName) break; 
		}
		for(; i<4;++i)
        {
			knapsackItems[i].sprite = knapsackItems[i + 1].sprite;
			knapsackItemName[i] = knapsackItemName[i + 1];
		}
		knapsackItems[4].sprite = null;
		knapsackItemName[4] = "None";

		itemsCount--;
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
