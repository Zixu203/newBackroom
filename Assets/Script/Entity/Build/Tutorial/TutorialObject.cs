using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialObject : InteractableEntity
{
    public GameObject tutorialObject;
    public override void OnInteractIn()
    {
        GameController.getInstance.GetManager<GamePlayManager>().inGameUIController.startTutorialText();
        base.OnInteractIn();
    }
}
