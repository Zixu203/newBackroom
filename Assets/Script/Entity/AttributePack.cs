using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributePack {
    public enum AttributePackFlag {
        Attack
    }
    public BaseEntity Owner {get; set;}
    public float value;
}
