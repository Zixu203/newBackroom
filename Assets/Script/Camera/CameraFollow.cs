using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Tilemaps;

public class CameraFollow : MonoBehaviour {
    public PostProcessVolume postProcessVolume;
    public Vignette vignette;
    public void Awake() {
        postProcessVolume.profile.TryGetSettings<Vignette>(out vignette);
    }
    void Start() {
        
    }
    private void LateUpdate() {
        vignette.intensity.value = 1.0f - (float)(GameController.getInstance.targetPlayer.Attribute.hp / GameController.getInstance.targetPlayer.Attribute.maxHp * 0.5f);
        this.transform.position = new Vector3(
            GameController.getInstance.targetPlayer.transform.position.x,
            GameController.getInstance.targetPlayer.transform.position.y,
            -10
        );

    }
}
