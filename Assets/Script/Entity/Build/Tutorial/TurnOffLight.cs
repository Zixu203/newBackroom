using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffLight : InteractableEntity
{
    public GameObject myLight;
    public override void OnInteractIn()
    {
        myLight.SetActive(false);
        base.OnInteractIn();
        GameController.getInstance.GetManager<GamePlayManager>().inGameUIController.tutorialText.gameObject.SetActive(false);
    }
}
