using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : Door {
    public override void BeenInteract() {
        if (GameController.getInstance.targetPlayer.have_door_key==false){
            return;
        }
        if (base.is_open == false){
            GameController.getInstance.inGameUIController.popOutKnapsack("key");
        }
        base.BeenInteract();
    }
}
