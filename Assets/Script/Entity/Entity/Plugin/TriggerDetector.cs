using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TriggerDetector<T, U> : MonoBehaviour {
    public class TriggerElement : EventArgs {
        public U element { get; }
        public TriggerElement(U element) {
            this.element = element;
        }
    }
    [SerializeField] private T baseEntity;
    private List<U> colliderBaseEntityList = new List<U>();
    protected T BaseEntity { get { return this.baseEntity; } }
    protected List<U> ColliderBaseEntityList { get { return this.colliderBaseEntityList; } }
    public EventHandler<TriggerElement> OnTriggerEnterEvent;
    public EventHandler<TriggerElement> OnTriggerExitEvent;
    public EventHandler<IEnumerable<TriggerElement>> OnUpdateEvent;
    public virtual void Update() {
        if(this.ColliderBaseEntityList.Count != 0){
            this.OnUpdateEvent?.Invoke(this, this.ColliderBaseEntityList.Select(x=>new TriggerElement(x)));
        }
    }
    public virtual void OnTriggerEnterAction(U obj) {
        this.OnTriggerEnterEvent?.Invoke(this, new TriggerElement(obj));
    }
    public virtual void OnTriggerExitAction(U obj) {
        this.OnTriggerExitEvent?.Invoke(this, new TriggerElement(obj));
    }
    private void OnTriggerEnter2D(Collider2D collider) {
        U colliEntity = collider.gameObject.GetComponent<U>();
        if(colliEntity == null) return;
        this.colliderBaseEntityList.Add(colliEntity);
        this.OnTriggerEnterAction(colliEntity);
    }
    private void OnTriggerExit2D(Collider2D collider) {
        U colliEntity = collider.gameObject.GetComponent<U>();
        if(colliEntity == null) return;
        this.colliderBaseEntityList.Remove(colliEntity);
        this.OnTriggerExitAction(colliEntity);
    }
}
