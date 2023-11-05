using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Interactor : TriggerDetector<BaseEntity, InteractableEntity> {
    public void Interact() {
        base.ColliderBaseEntityList.OrderBy(x=>Vector2.Distance(this.gameObject.transform.position, x.transform.position)).FirstOrDefault()?.BeenInteract();
    }
    public void InteractAll() {
        foreach(var baseEntity in base.ColliderBaseEntityList) {
            baseEntity.BeenInteract();
        }
    }
    public override void OnTriggerEnterAction(InteractableEntity obj) {
        obj.ShowInteractor();
    }
    public override void OnTriggerExitAction(InteractableEntity obj) {
        obj.HideInteractor();
    }
}
