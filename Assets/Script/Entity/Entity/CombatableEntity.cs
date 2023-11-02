using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatableEntity : BaseEntity {
    [SerializeField] protected float moveSpeed;
    protected Vector2 direction;
    public Vector2 Direction {
        get { return this.direction; }
        set { this.direction = value; }
    }
    [SerializeField] protected Animator animator;
    public Animator Animator {
        get { return this.animator; }
        set { this.animator = value; }
    }
    [SerializeField] protected Rigidbody2D rigidBody2D;
    protected Attribute attribute = new Attribute();
    public Attribute Attribute { get { return this.attribute; } }
    protected virtual void FixedUpdate() {
        this.rigidBody2D.velocity = direction.normalized * moveSpeed * Time.deltaTime;
    }
}
