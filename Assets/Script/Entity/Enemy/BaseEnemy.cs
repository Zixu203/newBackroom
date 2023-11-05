using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class BaseEnemy : CombatableEntity {
    [Header("enemy plugin")]
    [SerializeField] protected BaseEnemyAnime baseEnemyAnime;
    public BaseEnemyAnime BaseEnemyAnime { get { return this.baseEnemyAnime; } }
    [SerializeField] protected BaseEnemyActionMachine baseEnemyActionMachine;
    public BaseEnemyActionMachine BaseEnemyActionMachine { get { return this.baseEnemyActionMachine; } }
    [Header("feeling system")]
    [SerializeField] protected EnemyHearingDetector enemyHearingDetector;
    public EnemyHearingDetector EnemyHearingDetector { get { return this.enemyHearingDetector; } }
    [SerializeField] protected EnemyVisionDetector enemyVisionDetector;
    public EnemyVisionDetector EnemyVisionDetector { get { return this.enemyVisionDetector; } }
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
    public NavMeshAgent NavMeshAgent { get { return this.navMeshAgent; } }

    Vector3 spawnPosition;
    public Vector3 SpawnPosition { get { return this.spawnPosition; } }
    Quaternion spawnRotation;
    public Quaternion SpawnRotation { get { return this.spawnRotation; } }
    protected override void Start() {
        this.Init();
        this.Attribute.OnDeadEvent += (s, e) => this.baseEnemyActionMachine.Die();
        this.Attribute.OnDeadEvent += (s, e) => this.baseEnemyAnime.Die();
        this.Attribute.OnBeenAtackEvent += (s, e) => this.baseEnemyActionMachine.BeenAttack();
        this.Attribute.OnBeenAtackEvent += (s, e) => this.baseEnemyAnime.BeenAttack();
        this.EnemyHearingDetector.OnTriggerEnterEvent += (s, e) => this.baseEnemyActionMachine.HearSound(e.element.Owner.transform.position);
        this.enemyHearingDetector.OnTriggerEnterEvent += (s, e) => this.EnemyVisionDetector.lookAt(e.element.Owner.transform);
        this.EnemyVisionDetector.OnUpdateEvent += (s, e) => this.baseEnemyActionMachine.SetChaseTarget(e.FirstOrDefault().element.transform);
        this.enemyVisionDetector.OnUpdateEvent += (s, e) => this.EnemyVisionDetector.lookAt(e.FirstOrDefault().element.transform);
        this.spawnPosition = this.transform.position;
        this.spawnRotation = this.transform.rotation;
        GameController.getInstance.gamingPool.RegisterGamingPool(this.EnemyName, this.gameObject);
    }

    protected void Init() {
        base.attribute = new Attribute(10, 1, 1, 1, 1);
    }

    protected override void Update() {

    }

    protected override void FixedUpdate() {
        base.FixedUpdate();
    }

    protected void OnDrawGizmos() {
        // Vector3 origin = new Vector3 (0,0,0);
        // Vector3 direction = new Vector3 (1,0,0);
        // Gizmos.color = Color.red;
        // Gizmos.DrawWireSphere(this.gameObject.transform.position, scapeRange);
        // Gizmos.color = Color.yellow;
        // Gizmos.DrawWireSphere(this.gameObject.transform.position, attackRange);
        // Gizmos.color = Color.green;
        // Gizmos.DrawWireSphere(this.gameObject.transform.position, chaseRange);
        // Gizmos.color = Color.blue;
        // Gizmos.DrawWireSphere(this.gameObject.transform.position, patrolRange);
    }
}
