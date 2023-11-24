using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Speaker : BaseBuild {
    public bool power;
    float lastTime = 0;
    [SerializeField] float stepTime;
    [SerializeField] AudioSource audioSource;
    protected override void Update() {
        if(Time.time - lastTime > stepTime) {
            if(power) this.MakeSound();
            lastTime = Time.time;
        }
    }
    public override void BeenInteract() {
        power = !power;
        if(power) {
            audioSource.Play();
        } else {
            audioSource.Stop();
        }
    }
    protected virtual void MakeSound() {
        GamingPoolGameObject bubble = GameController.getInstance.GetManager<GamePlayManager>().gamingPool.GetGameObject("SoundBubble", this.gameObject.transform.position, quaternion.identity);
        bubble.GetComponent<SoundBubble>().Init(this, SoundBubble.SoundBubbleType.Eletronic, 20);
    }
}
