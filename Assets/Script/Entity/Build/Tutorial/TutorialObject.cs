using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialObject : BaseBuild
{
    public GameObject tutorialObject;   
    public override void BeenInteract() {
        this.gameObject.SetActive(false);
        GameController.getInstance.GetManager<GamePlayManager>().inGameUIController.startTutorialText();
        
    }
}
