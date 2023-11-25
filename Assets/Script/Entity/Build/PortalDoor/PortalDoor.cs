using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PortalDoor_a : BaseBuild
{
    public GameObject door_a, door_b;
    public bool is_open = false;
    public BoxCollider2D BoxCollider2D;
    public AudioSource audioSource;
    public AudioClip doorOpenSound;
    public AudioClip doorCloseSound;
    public override void BeenInteract()
    {
        if (is_open && !Input.GetKey(KeyCode.G))
        {
            GameController.getInstance.GetManager<GamePlayManager>().GetTargetPlayer.transform.position = door_b.transform.position + Vector3.down*0.5f;
            door_a.SetActive(false);
            door_b.SetActive(false);
            is_open = false;
            return;
        }
        GamingPoolGameObject bubble = GameController.getInstance.GetManager<GamePlayManager>().gamingPool.GetGameObject("SoundBubble", this.gameObject.transform.position + Vector3.down * 2.5f, quaternion.identity);
        bubble.GetComponent<SoundBubble>().Init(this, SoundBubble.SoundBubbleType.Wood, 10);
        is_open = !is_open;
        if (is_open)
        {
            this.audioSource.clip = doorOpenSound;
        }
        else
        {
            this.audioSource.clip = doorCloseSound;
        }
        this.audioSource.Play();
        door_a.SetActive(is_open);
        door_b.SetActive(is_open);
        //BoxCollider2D.isTrigger = is_open;
    }
}
