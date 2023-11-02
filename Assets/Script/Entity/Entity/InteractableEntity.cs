using UnityEngine;

public class InteractableEntity : BaseEntity {
    [SerializeField] private GameObject interactHint;
    public void ShowInteractor() {
        if(this.interactHint) this.interactHint.SetActive(true);
    }
    public void HideInteractor() {
        if(this.interactHint) this.interactHint.SetActive(false);
    }
    public virtual void BeenInteract() {
        
    }
}
