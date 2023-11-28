using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialKey : BaseBuild
{
    // Start is called before the first frame update
    public GameObject tutorialKey;
    public GameObject myLight;
    //public BoxCollider2D KeyCollider2D;
    public override void BeenInteract()
    {
        myLight.SetActive(false);
        this.gameObject.SetActive(false);
        GameController.getInstance.GetManager<GamePlayManager>().inGameUIController.pushInKnapsack("key");
        GameController.getInstance.GetManager<GamePlayManager>().GetTargetPlayer.have_door_key = true;
        GameController.getInstance.GetManager<GamePlayManager>().inGameUIController.tutorialKnapsack();
    }
}