using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatableEntity : BaseEntity {
    [Header("CombatableAttribute")]
    [SerializeField] protected float moveSpeed;
    public float MoveSpeedMultiplier { get; set; }
    [SerializeField] protected float maxHealth;
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
    public Rigidbody2D Rigidbody2D {
        get { return this.rigidBody2D; }
    }
    [SerializeField] protected CircleCollider2D _collider2D;
    public CircleCollider2D Collider2D {
        get { return this._collider2D; }
    }
    protected Attribute attribute = new Attribute();
    public Attribute Attribute { get { return this.attribute; } }
    protected override void Start() {
        base.Start();
        this.MoveSpeedMultiplier = 1f;

    }
    protected virtual void FixedUpdate() {
        this.rigidBody2D.velocity = direction.normalized * moveSpeed * this.MoveSpeedMultiplier * Time.deltaTime;
    }
}
