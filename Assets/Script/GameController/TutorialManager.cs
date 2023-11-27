using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager :GamePlayManager {

    public Text tutorialText;
    public List<GameObject> tutorialList;
    public List<GameObject> lightList;
    public override void Start() {
        base.Start();
        GameController.getInstance.GetManager<GamePlayManager>().inGameUIController.tutorialInit();
    }
    public override void Update() {
        base.Update();
    }
}
