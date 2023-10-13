using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public GameObject targetPlayer;
    public static GameController instance;
    public static GameController getInstance {
        get {
            if (GameController.instance == null)
                return GameController.instance = new GameController();
            return GameController.instance;
        }
    }
    [SerializeField]
    public List<BaseEntity> npcs;
    public DialogueSystem dialogueSystem;
    public GamingPoolSystem gamingPool = new GamingPoolSystem();
    void Awake() {
        GameController.instance = this;
    }
    void Start() {
        SaveLoader.Load();
        this.dialogueSystem = new DialogueSystem();
        this.dialogueSystem.init();
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private static void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
    }

    void Update() {
        
    }

    public void LoadInGame() {

    }

}
