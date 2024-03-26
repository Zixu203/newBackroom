using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBuild : InteractableEntity {
    public override void BeenInteract() {
        Debug.Log(this.name + "been interact and say hi.");
    }
}
