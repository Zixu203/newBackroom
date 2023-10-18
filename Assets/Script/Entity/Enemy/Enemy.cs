using System;
using System.Collections;
using System.Collections.Generic;
using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : BaseEntity {
    enum State {
        Idle,
        Walk,
        Chase,
        Attack,
        Scape
    }
    [SerializeField]
    float patrolRange;
    [SerializeField]
    float chaseRange;
    [SerializeField]
    float attackRange;
    [SerializeField]
    float scapeRange;
    State state = State.Idle;
    GameObject target;
    [SerializeField]
    NavMeshAgent navMeshAgent;
    private Enemy.State disToState(float dis) {
        if(dis <= scapeRange) return State.Scape;
        if(dis <= attackRange) return State.Attack;
        if(dis <= chaseRange) return State.Chase;
        if(dis <= patrolRange) return State.Walk;
        return State.Idle;
    }
    protected override void Start() {
        
    }

    protected override void Update() {
        // this.state = this.disToState(Vector2.Distance(this.gameObject.transform.position, this.target.transform.position));
        switch(this.state) {
            case State.Idle:
                break;
            case State.Walk:
                break;
            case State.Chase:
                break;
            case State.Attack:
                break;
            case State.Scape:
                break;
        }
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
