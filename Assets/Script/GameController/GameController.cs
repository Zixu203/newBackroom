using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public Player targetPlayer;
    public static GameController instance;
    public static GameController getInstance {
        get {
            if (GameController.instance == null)
                return GameController.instance = new GameController();
            return GameController.instance;
        }
        
    }
    public EnemySpawner enemySpawner;
    public GamingPoolSystem gamingPool;
    public DialogueSystem dialogueSystem;
    public InGameUIController inGameUIController;
    void Awake() {
        GameController.instance = this;
    }
    void Start() {
        SaveLoader.Load();
        this.inGameUIController = new InGameUIController();
        this.inGameUIController.init();
        //this.dialogueSystem = new DialogueSystem();
        this.dialogueSystem.init();
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
        // enemySpawner = new EnemySpawner();
        // this.gamingPool = new GamingPoolSystem();
        this.enemySpawner.Start();
    }

    void Update() {
        this.enemySpawner.Update();
    }
    public void changeWorld() {
        //in backroom scene
        if(SceneManager.GetActiveScene().name == "BackRoomScenes") {
            SaveLoader.setPositionInBackRoomScene(GameController.getInstance.targetPlayer.transform.position);
            SceneManager.LoadScene("SimilarWorldScenes");
        }
        //in similarWorld scene
        if(SceneManager.GetActiveScene().name == "SimilarWorldScenes") {
            SceneManager.LoadScene("BackRoomScenes");
        }
    }
    private static void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        GameController.getInstance.targetPlayer = GameObject.Find("player").GetComponent<Player>();
        if(scene.name == "BackRoomScenes") {
            GameController.getInstance.targetPlayer.transform.position = SaveLoader.getPositionInBackRoomScene();
        }
    }

    public void LoadInGame() {

    }

}
