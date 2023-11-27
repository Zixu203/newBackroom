using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    private Manager manager;
    public static GameController instance;
    public static GameController getInstance {
        get {
            if (GameController.instance == null)
                return GameController.instance = new GameController();
            return GameController.instance;
        }
        
    }
    void Awake() {
        if(GameController.instance != null){
            Destroy(this.gameObject);
            return;
        }
        GameController.instance = this;
        GameObject manager = GameObject.Find("Manager");
        if(manager != null) GameController.getInstance.manager = manager.GetComponent<Manager>();
    }
    void Start() {
        Debug.Log("Data load at : " + SaveLoader.baseDir);
        SaveLoader.Load();
        //first game time should run.
        SaveLoader.setIsRespawnPointUsed(true);
        SaveLoader.setDeadTime(0);
        //first game time should run.
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
        // enemySpawner = new EnemySpawner();
        // this.gamingPool = new GamingPoolSystem();
    }

    void Update() {
    }
    public void changeWorld() {
        //in backroom scene
        if(SceneManager.GetActiveScene().name == "BackRoomScenes") {
            SaveLoader.setPositionInBackRoomScene(GameController.getInstance.GetManager<GamePlayManager>().GetTargetPlayer.transform.position);
            SceneManager.LoadScene("SimilarWorldScenes");
        }
        //in similarWorld scene
        if(SceneManager.GetActiveScene().name == "SimilarWorldScenes") {
            SceneManager.LoadScene("BackRoomScenes");
        }
    }
    private static void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        GameObject manager = GameObject.Find("Manager");
        if(manager != null) GameController.getInstance.manager = manager.GetComponent<Manager>();
        if(scene.name == "BackRoomScenes") {
            // GameController.getInstance.targetPlayer = GameObject.Find("player").GetComponent<Player>();
            GameController.getInstance.GetManager<GamePlayManager>().GetTargetPlayer.transform.position = SaveLoader.getPositionInBackRoomScene();
        }
        if(scene.name == "SimilarWorldScenes") {
            // GameController.getInstance.targetPlayer = GameObject.Find("player").GetComponent<Player>();
            GameController.getInstance.GetManager<GamePlayManager>().inGameUIController.init();
        }
    }

    public static T GetInsManager<T>() where T : Manager {
        return GameController.getInstance.GetManager<T>();
    }

    public T GetManager<T>() where T : Manager {
        return this.manager as T;
    }

    public void LoadInGame() {

    }
}
