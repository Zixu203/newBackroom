using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class build : BaseEntity {
    protected override void Start() {
        
    }
    protected override void Update() {
        
    }
    public override void BeenInteract() {
        Debug.Log(this.name + "been interact and say hi.");
    }
}
