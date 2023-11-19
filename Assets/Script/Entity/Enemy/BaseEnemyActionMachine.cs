using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class BaseEnemyActionMachine : MonoBehaviour {
    [SerializeField] private State CurrentState;
    [SerializeField] IdleState idleState;
    public IdleState IdleState { get { return this.idleState; } }
    [SerializeField] PatrolState patrolState;
    public PatrolState PatrolState { get { return this.patrolState; } }
    [SerializeField] WalkState walkState;
    public WalkState WalkState { get { return this.walkState; } }
    [SerializeField] ChaseState chaseState;
    public ChaseState ChaseState { get { return this.chaseState; } }
    [SerializeField] AttackState attackState;
    public AttackState AttackState { get { return this.attackState; } }
    [SerializeField] SearchState searchState;
    public SearchState SearchState { get { return this.searchState; } }
    [SerializeField] BeenAttackState beenAttackState;
    public BeenAttackState BeenAttackState { get { return this.beenAttackState; } }
    [SerializeField] DeadState deadState;
    public DeadState DeadState { get { return this.deadState; } }
    public bool die = false;
    [SerializeField] protected BaseEnemy baseEnemy;
    public BaseEnemy BaseEnemy { get { return this.baseEnemy; } }
    private Vector3 lastTargetPosition;
    public Vector3 LastTargetPosition { get { return this.lastTargetPosition; } }
    private NavMeshPath navMeshPath;
    public NavMeshPath NavMeshPath { get { return this.navMeshPath; } }
    public Vector3 GetNearBySpawnPosition() {
        Vector3 nearPosition;
        do{
            nearPosition = this.baseEnemy.SpawnPosition + new Vector3(UnityEngine.Random.Range(2f, 5f), UnityEngine.Random.Range(2f, 5f), 0);
        } while(!this.baseEnemy.NavMeshAgent.CalculatePath(nearPosition, navMeshPath));
        return nearPosition;
    }
    public void ChangeState(State state) {
        if(this.CurrentState.CheckChange(state)){
            this.CurrentState.Exit();
            this.CurrentState = state;
            this.CurrentState.Init();
            this.CurrentState.Enter();
        }
    }    
    public virtual void Start() {
        this.navMeshPath = new NavMeshPath();
        lastTargetPosition = this.gameObject.transform.position;
        this.CurrentState = this.idleState;
        this.CurrentState.Init();
        this.CurrentState.Enter();
    }
    public virtual void Update() {
        Debug.Log(this.CurrentState);
        this.baseEnemy.Direction = Vector2.zero;
        this.CurrentState.Update();
        if(this.die) return;
    }
    public virtual void SetChaseTarget(Transform transform) {
        this.lastTargetPosition = transform.position;
        this.ChangeState(this.ChaseState);
    }
    public virtual void HearSound(Vector3 targetPosition) {
        this.lastTargetPosition = targetPosition;
        this.ChangeState(this.WalkState);
    }
    public virtual void BeenAttack(OnBeenAttackArg onBeenAttackArg) {
        this.baseEnemy.Rigidbody2D.AddForce(onBeenAttackArg.inputVector * 500000);
        this.ChangeState(this.BeenAttackState);
    }

    public virtual void Die() {
        this.die = true;
        this.BaseEnemy.Collider2D.enabled = false;
        // this.BaseEnemy.Collider2D.isTrigger = true;
        // Debug.Log(this.baseEnemy.Collider2D);
        this.ChangeState(this.DeadState);
    }
    public virtual void Dead() {
        GameController.getInstance.enemySpawner.EnemyDie(this.baseEnemy);
    }
}
