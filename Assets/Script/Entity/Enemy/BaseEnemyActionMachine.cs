using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private BaseEnemyActionMachine.State disToState(float dis) {
        if(dis <= this.baseEnemy.scapeRange) return State.Scape;
        if(dis <= this.baseEnemy.attackRange) return State.Attack;
        if(dis <= this.baseEnemy.chaseRange) return State.Chase;
        if(dis <= this.baseEnemy.patrolRange) return State.Walk;
        return State.Idle;
    }
    void Start() {
        
    }
    public virtual void Update() {
        this.state = this.disToState(Vector2.Distance(this.gameObject.transform.position, GameController.getInstance.targetPlayer.transform.position));
        this.baseEnemy.Direction = Vector2.zero;
        if(this.die) return;
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
        this.baseEnemy.BaseEnemyAnime.Update();
    }
    public virtual void Idle() {
        // this.navMeshAgent.isStopped = true;
    }
    
    public virtual void Walk() {

    }

    public virtual void Chase() {
        // this.navMeshAgent.SetDestination(GameController.getInstance.targetPlayer.transform.position);
        this.baseEnemy.Direction = (GameController.getInstance.targetPlayer.transform.position - this.transform.position).normalized;
    }

    public virtual void Attack() {

    }

    public virtual void Scape() {
        this.baseEnemy.Direction = (this.transform.position - GameController.getInstance.targetPlayer.transform.position).normalized;
    }

    public virtual void BeenAttack() {
        this.baseEnemy.BaseEnemyAnime.BeenAttack();
    }

    public virtual void Die() {
        this.die = true;
        this.baseEnemy.BaseEnemyAnime.Die();
    }
    public virtual void Dead() {
        GameController.getInstance.enemySpawner.EnemyDie(this.baseEnemy);
    }
}
