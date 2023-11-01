using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Interactor : MonoBehaviour {
    [SerializeField]
    private BaseEntity baseEntity;
    private List<InteractableEntity> colliderBaseEntityList = new List<InteractableEntity>();
    public BaseEntity GetBaseEntity(){
        return this.baseEntity;
    }
    public List<InteractableEntity> GetColliderBaseEntityList(){
        return this.colliderBaseEntityList;
    }

    public void Interact() {
        var firstCollider = colliderBaseEntityList.OrderBy(x=>Vector2.Distance(this.gameObject.transform.position, x.transform.position)).FirstOrDefault();
        if(firstCollider == null) return;
        firstCollider.BeenInteract();
    }
    public void InteractAll() {
        foreach(var baseEntity in this.colliderBaseEntityList) {
            baseEntity.BeenInteract();
        }
    }
    private void OnTriggerEnter2D(Collider2D collider) {
        InteractableEntity colliEntity = collider.gameObject.GetComponent<InteractableEntity>();
        if(colliEntity == null) return;
        this.colliderBaseEntityList.Add(colliEntity);
        colliEntity.ShowInteractor();
    }
    private void OnTriggerExit2D(Collider2D collider) {
        InteractableEntity colliEntity = collider.gameObject.GetComponent<InteractableEntity>();
        if(colliEntity == null) return;
        this.colliderBaseEntityList.Remove(colliEntity);
        colliEntity.HideInteractor();
    }
}
