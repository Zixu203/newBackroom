using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseNPC : InteractableEntity {
    public override void BeenInteract() {
        GameController.getInstance.GetManager<GamePlayManager>().dialogueSystem.StartDialogue(this);
    }
}
