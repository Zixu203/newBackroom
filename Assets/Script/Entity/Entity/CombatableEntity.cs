using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatableEntity : BaseEntity {
    [SerializeField]
    protected float moveSpeed;
    protected Vector2 direction;
    [SerializeField]
    protected Animator animator;
    [SerializeField]
    protected Rigidbody2D rigidBody2D;
    protected Attribute attribute = new Attribute();
    
    public Attribute GetAttribute() {
        return this.attribute;
    }
    protected virtual void FixedUpdate() {
        this.rigidBody2D.velocity = direction.normalized * moveSpeed * Time.deltaTime;
    }
}
