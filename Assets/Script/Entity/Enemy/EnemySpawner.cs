using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class EnemySpawner {
    private static float respawnTime = 5f;
    [SerializeField] public List<Enemy> enemies;
    private List<Tuple<Enemy, float>> waitingEnemies = new List<Tuple<Enemy, float>>();
    public EnemySpawner() {

    }
    public void Start() {
        foreach(var enemy in this.enemies) {
            GameController.getInstance.gamingPool.RegisterGamingPool(enemy.GetEnemyName(), enemy.gameObject);
        }
    }
    public void Update() {
        for (int i = this.waitingEnemies.Count - 1; i >= 0; i--) {
            if(Time.time - this.waitingEnemies[i].Item2 > EnemySpawner.respawnTime) {
                GameController.getInstance.gamingPool.GetGameObject(
                    this.waitingEnemies[i].Item1.GetEnemyName(),
                    this.waitingEnemies[i].Item1.GetSpawnPosition(),
                    this.waitingEnemies[i].Item1.GetSpawnRotation()
                );
                this.waitingEnemies.RemoveAt(i);
            }
        }
    }

    public void EnemyDie(Enemy enemy) {
        if(enemy.GetSpawnType() == Enemy.SpawnType.Common){
            this.waitingEnemies.Add(new Tuple<Enemy, float>(enemy, Time.time));
        }
        GameController.getInstance.gamingPool.GiveBackGameObject(enemy.GetEnemyName(), enemy.gameObject);
    }
}
