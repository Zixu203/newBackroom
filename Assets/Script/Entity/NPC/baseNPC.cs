using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseNPC : InteractableEntity {
    public string InDialogueName;

    public void EndDialogue(){
        this.gameObject.SetActive(false);
    }
    public override void BeenInteract() {
        GameController.getInstance.GetManager<GamePlayManager>().dialogueSystem.StartDialogue(this);
    }
}
