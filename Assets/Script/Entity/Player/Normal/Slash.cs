using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour {
    AttributePack attributePack;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }
    public void setAttribute(AttributePack attributePack) {
        this.attributePack = attributePack;
    }

    private void OnTriggerEnter2D(Collider2D collider2D) {
        var baseEntity = collider2D.gameObject.GetComponent<BaseEntity>();
        Debug.Log(baseEntity);
    }
}
