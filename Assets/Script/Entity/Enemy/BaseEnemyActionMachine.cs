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
    [SerializeField] IdleState idleState;
    public IdleState IdleState { get { return this.idleState; } }
    [SerializeField] PatrolState patrolState;
    public PatrolState PatrolState { get { return this.patrolState; } }
    [SerializeField] WalkState walkState;
    public WalkState WalkState { get { return this.walkState; } }
    [SerializeField] AttackState attackState;
    public AttackState AttackState { get { return this.attackState; } }
    
    private State CurrentState;
    public bool die = false;
    // enum State {
    //     Idle = 0,
    //     Walk = 1,
    //     StartChase = 2,
    //     Chasing = 3,
    //     Attack = 4,
    //     Scape = 5
    // }
    // const int StateCount = 6;

    // [SerializeField] State state = State.Idle;
    [SerializeField] protected BaseEnemy baseEnemy;
    public BaseEnemy BaseEnemy { get { return this.baseEnemy; } }
    private Vector3 lastTargetPosition;
    private NavMeshPath navMeshPath;
    public NavMeshPath NavMeshPath { get { return this.navMeshPath; } }
    // private BaseEnemyActionMachine.State disToState(float dis) {
    //     return State.Idle;
    // }
    // public List<List<Func<bool>>> StateTransferMatrix;
    // private BaseEnemyActionMachine.State StateTransfer(BaseEnemyActionMachine.State oldState) {
    //     for(int i = 0; i < StateCount; ++i) {
    //         if(this.StateTransferMatrix[(int)oldState][i]()){
    //             return (State)i;
    //         }
    //     }
    //     return oldState;
    // }
    public Vector3 GetNearBySpawnPosition() {
        Vector3 nearPosition;
        do{
            nearPosition = this.baseEnemy.SpawnPosition + new Vector3(UnityEngine.Random.Range(2f, 5f), UnityEngine.Random.Range(2f, 5f), 0);
        } while(!this.baseEnemy.NavMeshAgent.CalculatePath(nearPosition, navMeshPath));
        return nearPosition;
    }
    public void ChangeState(State state) {
        this.CurrentState.Exit();
        this.CurrentState = state;
        this.CurrentState.Init();
        this.CurrentState.Enter();
    }    
    public virtual void Start() {
        this.navMeshPath = new NavMeshPath();
        lastTargetPosition = this.gameObject.transform.position;
        this.CurrentState = this.idleState;
        this.CurrentState.Init();
        this.CurrentState.Enter();
        // StateTransferMatrix = new List<List<Func<bool>>>(StateCount);
        // for (int i = 0; i < StateCount; ++i) {
        //     this.StateTransferMatrix.Add(new List<Func<bool>>(StateCount));
        //     for (int j = 0; j < StateCount; ++j) {
        //         this.StateTransferMatrix[i].Add(() => false);
        //     }
        // }
        // this.StateTransferMatrix[(int)State.Idle][(int)State.Walk] = () => {
        //     return false;
        // };
    }
    public virtual void Update() {
        // this.state = this.StateTransfer(this.state);
        this.baseEnemy.Direction = Vector2.zero;
        this.CurrentState.Update();
        if(this.die) return;
        // switch(this.state) {
        //     case State.Idle:
        //         this.Idle();
        //         break;
        //     case State.Walk:
        //         this.Walk();
        //         break;
        //     case State.Chase:
        //         this.Chase();
        //         break;
        //     case State.Attack:
        //         this.Attack();
        //         break;
        //     case State.Scape:
        //         this.Scape();
        //         break;
        // }
        // this.Chase();
        // this.baseEnemy.BaseEnemyAnime.Update();
    }
    public virtual void Idle() {
        // this.navMeshAgent.isStopped = true;
    }
    
    public virtual void Walk() {

    }
    public virtual void SetChaseTarget(Transform transform) {
        this.lastTargetPosition = transform.position;
    }
    public virtual void HearSound(Vector3 targetPosition) {
        this.lastTargetPosition = targetPosition;
    }
    public virtual void Chase() {
        if(Vector2.Distance(this.gameObject.transform.position, this.lastTargetPosition) < 1.3f) {
            return;
        }
        bool isRoadFound = this.baseEnemy.NavMeshAgent.CalculatePath(this.lastTargetPosition, navMeshPath);
        if(isRoadFound) {
            this.baseEnemy.Direction = (navMeshPath.corners[1] - this.transform.position).normalized;
        }
    }

    public virtual void Attack() {

    }

    public virtual void Scape() {
        this.baseEnemy.Direction = (this.transform.position - GameController.getInstance.targetPlayer.transform.position).normalized;
    }

    public virtual void BeenAttack(OnBeenAttackArg onBeenAttackArg) {
        this.baseEnemy.Rigidbody2D.AddForce(-onBeenAttackArg.inputVector * 10000);
    }

    public virtual void Die() {
        this.die = true;
    }
    public virtual void Dead() {
        GameController.getInstance.enemySpawner.EnemyDie(this.baseEnemy);
    }
}
