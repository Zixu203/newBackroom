using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class BaseEnemyActionMachine : MonoBehaviour {
    public bool die = false;
    enum State {
        Idle,
        Walk,
        Chase,
        Attack,
        Scape
    }

    [SerializeField] State state = State.Idle;
    [SerializeField] protected BaseEnemy baseEnemy;
    private Vector3 lastTargetPosition;
    private BaseEnemyActionMachine.State disToState(float dis) {
        if(dis <= this.baseEnemy.scapeRange) return State.Scape;
        if(dis <= this.baseEnemy.attackRange) return State.Attack;
        if(dis <= this.baseEnemy.chaseRange) return State.Chase;
        if(dis <= this.baseEnemy.patrolRange) return State.Walk;
        return State.Idle;
    }
    void Start() {
        lastTargetPosition = this.gameObject.transform.position;
    }
    public virtual void Update() {
        this.state = this.disToState(Vector2.Distance(this.gameObject.transform.position, GameController.getInstance.targetPlayer.transform.position));
        this.baseEnemy.Direction = Vector2.zero;
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
        this.Chase();
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
        NavMeshPath navMeshPath = new NavMeshPath();
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

    public virtual void BeenAttack() {

    }

    public virtual void Die() {
        this.die = true;
    }
    public virtual void Dead() {
        GameController.getInstance.enemySpawner.EnemyDie(this.baseEnemy);
    }
}
