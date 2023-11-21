using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Door : BaseBuild {
    public GameObject door;
    public bool is_open = false;
    public BoxCollider2D BoxCollider2D;
    public AudioSource audioSource;
    public AudioClip doorOpenSound;
    public AudioClip doorCloseSound;
    public override void BeenInteract() {
        if(is_open && !Input.GetKey(KeyCode.G)) {
            GameController.getInstance.changeWorld();
            return;
        }
        GamingPoolGameObject bubble = GameController.getInstance.gamingPool.GetGameObject("SoundBubble", this.gameObject.transform.position + Vector3.down * 2.5f, quaternion.identity);
        bubble.GetComponent<SoundBubble>().Init(this, SoundBubble.SoundBubbleType.Wood, 10);
        is_open = !is_open;
        if(is_open) {
            this.audioSource.clip = doorOpenSound;
        }else{
            this.audioSource.clip = doorCloseSound;
        }
        this.audioSource.Play();
        door.SetActive(is_open);
        BoxCollider2D.isTrigger = is_open;
    }
}
