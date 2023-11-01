using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseNPC : BaseEntity {
    protected override void Start() {
        
    }
    protected override void Update() {
        
    }
    public override void BeenInteract() {
        GameController.getInstance.dialogueSystem.StartDialogue(this);
    }
}
