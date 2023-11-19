using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBox : GamingPoolGameObject {
    AttributePack attributePack;
    [SerializeField] BoxCollider2D boxCollider2D;
    public void OnAnimeEnd() {
        this.gameObject.SetActive(false);
    }
    public void setAttribute(AttributePack attributePack) {
        this.attributePack = attributePack;

        StartCoroutine(waitAndGiveBack());
    }
    public IEnumerator waitAndGiveBack() {
        yield return new WaitForSeconds(0.1f);
        GameController.getInstance.gamingPool.GiveBackGameObject("AttackBox", this);
    }
    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(this.transform.position, this.boxCollider2D.size);
    }

    private void OnTriggerEnter2D(Collider2D collider2D) {
        var baseEntity = collider2D.gameObject.GetComponent<CombatableEntity>();
        if(baseEntity == null) return;
        baseEntity.Attribute.Damage(this.attributePack);
    }
}
