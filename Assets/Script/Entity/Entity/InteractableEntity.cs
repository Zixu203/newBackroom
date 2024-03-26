using System.Collections.Generic;
using UnityEngine;

public class InteractableEntity : BaseEntity {
    [SerializeField] private List<GameObject> interactHints;
    public virtual void OnInteractIn() {
        if(this.interactHints.Count > 0) this.interactHints.ForEach(x => x.SetActive(true));
    }
    public virtual void OnInteractOut() {
        if(this.interactHints.Count > 0) this.interactHints.ForEach(x => x.SetActive(false));
    }
    public virtual void BeenInteract() {
        
    }
}
