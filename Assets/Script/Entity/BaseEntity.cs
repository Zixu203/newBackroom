using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEntity : MonoBehaviour {
    
    [SerializeField]
    protected float moveSpeed;
    protected Vector2 direction;
    [SerializeField]
    protected Animator animator;
    [SerializeField]
    protected Rigidbody2D rigidBody2D;
    protected Attribute attribute = new Attribute();
    [SerializeField]
    private GameObject interactHint;
    
    public Attribute GetAttribute() {
        return this.attribute;
    }
    public void ShowInteractor() {
        this.interactHint.SetActive(true);
    }
    public void HideInteractor() {
        this.interactHint.SetActive(false);
    }
    public virtual void BeenInteract() {
        
    }

    protected virtual void Start() {
        
    }
    protected virtual void Update() {
        
    }
    protected virtual void FixedUpdate() {
        this.rigidBody2D.velocity = direction.normalized * moveSpeed * Time.deltaTime;
    }
}
