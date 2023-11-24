using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : Door {
    public AudioClip doorLockedSound;
    public override void BeenInteract() {
        if (GameController.getInstance.GetManager<GamePlayManager>().GetTargetPlayer.have_door_key==false){
            this.audioSource.clip = doorLockedSound;
            this.audioSource.Play();
            return;
        }
        if (base.is_open == false){
            GameController.getInstance.GetManager<GamePlayManager>().inGameUIController.popOutKnapsack("key");
        }
        base.BeenInteract();
    }
}
