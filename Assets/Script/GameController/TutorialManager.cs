using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager :GamePlayManager {

    public Text tutorialText;
    public override void Start() {
        tutorialText = GameObject.Find("UI").transform.GetChild(1).GetComponent<UnityEngine.UI.Text>();
        base.Start();
    }
    public override void Update() {
        base.Update();
    }
}
