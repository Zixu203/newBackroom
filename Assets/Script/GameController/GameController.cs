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
    [SerializeField]
    public List<BaseEntity> npcs;
    public DialogueSystem dialogueSystem;
    void Awake() {
        GameController.instance = this;
    }
    void Start() {
        SaveLoader.Load();
        // this.dialogueSystem = new DialogueSystem();
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
            SceneManager.LoadScene("SimilarWorldScenes");
        }
        //in similarWorld scene
        if(SceneManager.GetActiveScene().name == "SimilarWorldScenes") {
            SceneManager.LoadScene("BackRoomScenes");
        }
    }
    private static void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        GameController.getInstance.targetPlayer = GameObject.Find("player").GetComponent<Player>();
    }

    public void LoadInGame() {

    }

}
