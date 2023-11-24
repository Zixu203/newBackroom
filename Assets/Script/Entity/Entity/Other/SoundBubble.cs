using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBubble : GamingPoolGameObject {
    public enum SoundBubbleType { Normal, Eletronic, Wood }
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
        GameController.getInstance.GetManager<GamePlayManager>().gamingPool.GiveBackGameObject("SoundBubble", this);
    }
    private void OnDrawGizmos() {
        switch(this.SoundType) {
            case SoundBubbleType.Normal:
                Gizmos.color = Color.red;
                break;
            case SoundBubbleType.Eletronic:
                Gizmos.color = Color.blue;
                break;
            default:
                Gizmos.color = Color.red;
                break;
        }
        Gizmos.DrawWireSphere(this.gameObject.transform.position, this.circleCollider2D.radius);
    }
}
