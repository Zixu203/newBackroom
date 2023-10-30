using System;
using System.Collections;
using System.Collections.Generic;
using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : BaseEntity {
// public class Enemy : MonoBehaviour {
    enum State {
        Idle,
        Walk,
        Chase,
        Attack,
        Scape
    }
    public enum SpawnType {
        Common,
        Onetime
    }
    [SerializeField] string enemyName;
    [SerializeField] SpawnType spawnType = SpawnType.Common;
    [SerializeField] float patrolRange = 8f;
    [SerializeField] float chaseRange = 4f;
    [SerializeField] float attackRange = 1f;
    [SerializeField] float scapeRange = 0.5f;
    [SerializeField] NavMeshAgent navMeshAgent;

    Vector3 spawnPosition;
    Quaternion spawnRotation;

    [SerializeField]
    State state = State.Idle;
    private Enemy.State disToState(float dis) {
        if(dis <= scapeRange) return State.Scape;
        if(dis <= attackRange) return State.Attack;
        if(dis <= chaseRange) return State.Chase;
        if(dis <= patrolRange) return State.Walk;
        return State.Idle;
    }
    protected override void Start() {
        Debug.Log("enemy " + this.GetEnemyName() + "  start");
        base.attribute = new Attribute(10, 1, 1, 1, 1);
        this.GetAttribute().OnDead += () => this.Die();
        this.spawnPosition = this.transform.position;
        this.spawnRotation = this.transform.rotation;
        // this.navMeshAgent.updateRotation = false;
    }

    protected override void Update() {
        this.state = this.disToState(Vector2.Distance(this.gameObject.transform.position, GameController.getInstance.targetPlayer.transform.position));
        // base.direction *= 0.7f;
        base.direction = Vector2.zero;
        switch(this.state) {
            case State.Idle:
                this.Idle();
                break;
            case State.Walk:
                this.Walk();
                break;
            case State.Chase:
                this.Chase();
                break;
            case State.Attack:
                this.Attack();
                break;
            case State.Scape:
                this.Scape();
                break;
        }
        base.animator.SetFloat("x", base.direction.x);
        base.animator.SetBool("walk", base.direction.x != 0);
        if(Input.GetKeyDown(KeyCode.P)){
            this.Die();
        }
    }
    protected virtual void Idle() {
        // this.navMeshAgent.isStopped = true;
    }
    
    protected virtual void Walk() {

    }

    protected virtual void Chase() {
        // this.navMeshAgent.SetDestination(GameController.getInstance.targetPlayer.transform.position);
        base.direction = (GameController.getInstance.targetPlayer.transform.position - this.transform.position).normalized;
    }

    protected virtual void Attack() {

    }

    protected virtual void Scape() {
        base.direction = (this.transform.position - GameController.getInstance.targetPlayer.transform.position).normalized;
    }

    protected virtual void Die() {
        GameController.getInstance.enemySpawner.EnemyDie(this);
    }

    public string GetEnemyName() {
        return this.enemyName;
    }

    public SpawnType GetSpawnType() {
        return this.spawnType;
    }

    public Vector3 GetSpawnPosition() {
        return this.spawnPosition;
    }

    public Quaternion GetSpawnRotation() {
        return this.spawnRotation;
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
