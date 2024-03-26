using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributePack {
    public enum AttributePackFlag {
        Attack
    }
    public BaseEntity Owner {get; set;}
    public float value;
    public Vector2 inputVector;
    public AttributePack(BaseEntity owner, float value) : this(owner, value, Vector2.zero) { }
    public AttributePack(BaseEntity owner, float value, Vector2 inputVector) {
        this.Owner = owner;
        this.value = value;
        this.inputVector = inputVector;
    }
}
