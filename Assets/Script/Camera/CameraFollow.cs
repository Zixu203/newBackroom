using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Tilemaps;

public class CameraFollow : MonoBehaviour {
    public PostProcessVolume postProcessVolume;
    public Vignette vignette;
    public ColorGrading colorGrading;
    public void Awake() {
        if(postProcessVolume) {
            postProcessVolume.profile.TryGetSettings<Vignette>(out vignette);
            postProcessVolume.profile.TryGetSettings<ColorGrading>(out colorGrading);
        }
    }
    void Start() {
        
    }
    private void LateUpdate() {
        if(vignette){
            vignette.intensity.value = 1.0f - (float)(GameController.getInstance.targetPlayer.Attribute.hp / GameController.getInstance.targetPlayer.Attribute.maxHp * 0.5f);
        }
        if(colorGrading) {
            this.colorGrading.mixerGreenOutGreenIn.value = 100f * (float)(GameController.getInstance.targetPlayer.Attribute.hp / GameController.getInstance.targetPlayer.Attribute.maxHp);
            this.colorGrading.mixerBlueOutBlueIn.value = 100f * (float)(GameController.getInstance.targetPlayer.Attribute.hp / GameController.getInstance.targetPlayer.Attribute.maxHp);
        }
        this.transform.position = new Vector3(
            GameController.getInstance.targetPlayer.transform.position.x,
            GameController.getInstance.targetPlayer.transform.position.y,
            -10
        );

    }
}
