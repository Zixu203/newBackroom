using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : BaseBuild {
    public GameObject door;
    public bool is_open = false;
    public BoxCollider2D BoxCollider2D;
    public override void BeenInteract() {
        if (GameController.getInstance.targetPlayer.have_door_key==false){
            return;
        }
        if(is_open && !Input.GetKey(KeyCode.G)) {
            GameController.getInstance.changeWorld();
            return;
        }
        if (is_open == false){
            GameController.getInstance.inGameUIController.popOutKnapsack("key");
        }
        is_open = !is_open;
        door.SetActive(is_open);
        BoxCollider2D.isTrigger = is_open;
    }
}
