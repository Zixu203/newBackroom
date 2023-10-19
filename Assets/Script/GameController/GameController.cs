using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public EnemySpawner enemySpawner;
    public GamingPoolSystem gamingPool;
    void Awake() {
        GameController.instance = this;
    }
    void Start() {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
        // enemySpawner = new EnemySpawner();
        // this.gamingPool = new GamingPoolSystem();
        this.enemySpawner.Start();
    }

    void Update() {
        this.enemySpawner.Update();
    }

    private static void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
    }

    public void LoadInGame() {

    }

}
