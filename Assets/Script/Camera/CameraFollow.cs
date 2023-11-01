using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraFollow : MonoBehaviour {
    void Start() {
        
    }
    private void LateUpdate() {
        this.transform.position = new Vector3(
            GameController.getInstance.targetPlayer.transform.position.x,
            GameController.getInstance.targetPlayer.transform.position.y,
            -10
        );

    }
}
