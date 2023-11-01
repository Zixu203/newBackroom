using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Interactor : MonoBehaviour {
    [SerializeField]
    private BaseEntity baseEntity;
    private List<BaseEntity> colliderBaseEntityList = new List<BaseEntity>();
    void Start() {
    }
    void Update() {
    }
    public BaseEntity GetBaseEntity(){
        return this.baseEntity;
    }
    public List<BaseEntity> GetColliderBaseEntityList(){
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
    public void OnTriggerEnter2D(Collider2D collider) {
        BaseEntity colliEntity = collider.gameObject.GetComponent<BaseEntity>();
        if(colliEntity == null) return;
        this.colliderBaseEntityList.Add(colliEntity);
        colliEntity.ShowInteractor();
    }
    void OnTriggerExit2D(Collider2D collider) {
        BaseEntity colliEntity = collider.gameObject.GetComponent<BaseEntity>();
        if(colliEntity == null) return;
        this.colliderBaseEntityList.Remove(colliEntity);
        colliEntity.HideInteractor();
    }
}
