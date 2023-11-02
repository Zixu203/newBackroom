using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class EnemySpawner {
    private static float respawnTime = 5f;
    [SerializeField] public List<BaseEnemy> enemies;
    private List<Tuple<BaseEnemy, float>> waitingEnemies = new List<Tuple<BaseEnemy, float>>();
    public EnemySpawner() {

    }
    public void Start() {
        foreach(var enemy in this.enemies) {
            GameController.getInstance.gamingPool.RegisterGamingPool(enemy.EnemyName, enemy.gameObject);
        }
    }
    public void Update() {
        for (int i = this.waitingEnemies.Count - 1; i >= 0; i--) {
            if(Time.time - this.waitingEnemies[i].Item2 > EnemySpawner.respawnTime) {
                GameController.getInstance.gamingPool.GetGameObject(
                    this.waitingEnemies[i].Item1.EnemyName,
                    this.waitingEnemies[i].Item1.SpawnPosition,
                    this.waitingEnemies[i].Item1.SpawnRotation
                );
                this.waitingEnemies.RemoveAt(i);
            }
        }
    }

    public void EnemyDie(BaseEnemy enemy) {
        if(enemy.SpawnType == BaseEnemy.EnemySpawnType.Common){
            this.waitingEnemies.Add(new Tuple<BaseEnemy, float>(enemy, Time.time));
        }
        GameController.getInstance.gamingPool.GiveBackGameObject(enemy.EnemyName, enemy.gameObject);
    }
}
