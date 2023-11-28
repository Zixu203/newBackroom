using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCurebag : BaseBuild
{
    public GameObject curebag;
    public GameObject myLight;
    public override void BeenInteract() {
        this.gameObject.SetActive(false);
        myLight.SetActive(false);
        GameController.getInstance.GetManager<GamePlayManager>().GetTargetPlayer.Attribute.Heal(20);
        GameController.getInstance.GetManager<GamePlayManager>().inGameUIController.tutorialText.gameObject.SetActive(false);
        
    }
}
