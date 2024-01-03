using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCurebag : BaseBuild
{
    public GameObject curebag;
    public GameObject myLight;
    public override void BeenInteract() {
        this.gameObject.SetActive(false);
        GameController.getInstance.GetManager<GamePlayManager>().GetTargetPlayer.Attribute.Heal(20);      
    }
}
