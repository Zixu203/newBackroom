using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBubble : MonoBehaviour {
    public enum SoundBubbleType { Normal }
    private BaseEntity owner;
    public BaseEntity Owner { get { return this.owner; } private set { this.owner = value; } }
    private SoundBubbleType soundType;
    public SoundBubbleType SoundType { get { return this.soundType; } private set { this.soundType = value; } }
    [SerializeField] private CircleCollider2D circleCollider2D;

    public void Init(BaseEntity owner, SoundBubbleType soundType, int radius) {
        this.Owner = owner;
        this.SoundType = soundType;
        this.circleCollider2D.radius = radius;
        
        StartCoroutine(waitAndGiveBack());
    }
    public IEnumerator waitAndGiveBack() {
        yield return new WaitForSeconds(0.1f);
        GameController.getInstance.gamingPool.GiveBackGameObject("SoundBubble", this.gameObject);
    }
    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.gameObject.transform.position, this.circleCollider2D.radius);
    }
}