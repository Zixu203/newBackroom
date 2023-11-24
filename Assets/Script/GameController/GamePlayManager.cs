using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : Manager {
    [SerializeField] Player targetPlayer;
    public virtual Player GetTargetPlayer { get { return this.targetPlayer; } }
    public EnemySpawner enemySpawner;
    public GamingPoolSystem gamingPool;
    public DialogueSystem dialogueSystem;
    public InGameUIController inGameUIController;
    // Start is called before the first frame update
    public override void Start() {
        this.inGameUIController = new InGameUIController();
        this.inGameUIController.init();
        //this.dialogueSystem = new DialogueSystem();
        this.dialogueSystem.init();
        this.enemySpawner.Start();
    }

    float StepSaveTime = 10f;
    float TempSaveTime = 0;

    // Update is called once per frame
    public override void Update() {
        this.enemySpawner.Update();
        this.DeathSave();
    }
    void DeathSave() {
        if(!SaveLoader.getIsRespawnPointUsed()) return;

        TempSaveTime += Time.deltaTime;
        if(TempSaveTime < StepSaveTime) return;
        TempSaveTime = 0;

        if(Time.time > SaveLoader.getNextSaveTime()) {
            // Debug.Log("player respawn save, " + GameController.getInstance.targetPlayer.transform.position);
            SaveLoader.setIsRespawnPointUsed(false);
            SaveLoader.setLastRespawnPoint(this.targetPlayer.transform.position);
        }
    }
}
