using System.Collections.Generic;
using UnityEngine;

public class InteractableEntity : BaseEntity {
    // [SerializeField] private GameObject interactHint;
    [SerializeField] private List<GameObject> interactHints;
    public void ShowInteractor() {
        // if(this.interactHint) this.interactHint.SetActive(true);
        if(this.interactHints.Count > 0) this.interactHints.ForEach(x => x.SetActive(true));
    }
    public void HideInteractor() {
        // if(this.interactHint) this.interactHint.SetActive(false);
        if(this.interactHints.Count > 0) this.interactHints.ForEach(x => x.SetActive(false));
    }
    public virtual void BeenInteract() {
        
    }
}
