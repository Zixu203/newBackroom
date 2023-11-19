using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBox : MonoBehaviour {
    AttributePack attributePack;
    public Animator animator;
    public void OnAnimeEnd() {
        this.gameObject.SetActive(false);
    }
    public void setAttribute(AttributePack attributePack) {
        this.attributePack = attributePack;
    }

    private void OnTriggerEnter2D(Collider2D collider2D) {
        var baseEntity = collider2D.gameObject.GetComponent<CombatableEntity>();
        if(baseEntity == null) return;
        baseEntity.Attribute.Damage(this.attributePack);
    }
}
