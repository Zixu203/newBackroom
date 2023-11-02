using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.AI;

public class BaseEnemy : CombatableEntity {
    [SerializeField] protected BaseEnemyAnime baseEnemyAnime;
    public BaseEnemyAnime BaseEnemyAnime { get { return this.baseEnemyAnime; } }
    [SerializeField] protected BaseEnemyActionMachine baseEnemyActionMachine;
    public BaseEnemyActionMachine BbaseEnemyActionMachine { get { return this.baseEnemyActionMachine; } }
    public enum EnemySpawnType {
        Common,
        Onetime
    }
    [SerializeField] string enemyName;
    public string EnemyName { get { return this.enemyName; } }
    [SerializeField] EnemySpawnType spawnType = EnemySpawnType.Common;
    public EnemySpawnType SpawnType { get { return this.spawnType; } }
    [SerializeField] public float patrolRange = 8f;
    [SerializeField] public float chaseRange = 4f;
    [SerializeField] public float attackRange = 1f;
    [SerializeField] public float scapeRange = 0.5f;
    [SerializeField] NavMeshAgent navMeshAgent;

    Vector3 spawnPosition;
    public Vector3 SpawnPosition { get { return this.spawnPosition; } }
    Quaternion spawnRotation;
    public Quaternion SpawnRotation { get { return this.spawnRotation; } }
    protected override void Start() {
        this.Init();
        this.Attribute.OnDead += () => this.baseEnemyActionMachine.Die();
        this.Attribute.OnBeenAttack += () => this.baseEnemyActionMachine.BeenAttack();
        this.spawnPosition = this.transform.position;
        this.spawnRotation = this.transform.rotation;
        GameController.getInstance.gamingPool.RegisterGamingPool(this.EnemyName, this.gameObject);
    }

    protected void Init() {
        base.attribute = new Attribute(10, 1, 1, 1, 1);
    }

    protected override void Update() {
        Debug.Log(this.baseEnemyActionMachine);
        this.baseEnemyActionMachine.Update();
    }

    protected override void FixedUpdate() {
        base.FixedUpdate();
    }

    protected void OnDrawGizmos() {
        Vector3 origin = new Vector3 (0,0,0);
        Vector3 direction = new Vector3 (1,0,0);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.gameObject.transform.position, scapeRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(this.gameObject.transform.position, attackRange);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.gameObject.transform.position, chaseRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(this.gameObject.transform.position, patrolRange);
    }
}
