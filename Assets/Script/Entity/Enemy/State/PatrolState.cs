using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class PatrolState : State {
    [SerializeField] protected PatrolStateData patrolStateData;
    public PatrolState(BaseEnemyActionMachine baseEnemyActionMachine) : base(baseEnemyActionMachine) {
    }
    protected Vector3 destination;

    public override void Init() {
        base.Init();
        do{
            this.destination = this.baseEnemyActionMachine.BaseEnemy.SpawnPosition + new Vector3(UnityEngine.Random.Range(this.patrolStateData.minPatrolDistance, this.patrolStateData.maxPatrolDistance), UnityEngine.Random.Range(this.patrolStateData.minPatrolDistance, this.patrolStateData.maxPatrolDistance), 0);
        } while(!this.baseEnemyActionMachine.BaseEnemy.NavMeshAgent.CalculatePath(this.destination, this.baseEnemyActionMachine.NavMeshPath));
        this.destination = this.baseEnemyActionMachine.NavMeshPath.corners.Last();
    }
    public override void Enter() {
        base.Enter();
    }
    public override void Update() {
        base.Update();
        bool isRoadFound = this.baseEnemyActionMachine.BaseEnemy.NavMeshAgent.CalculatePath(this.destination, this.baseEnemyActionMachine.NavMeshPath);
        // Debug.Log(this.destination);
        // Debug.Log(isRoadFound);
        if(isRoadFound) {
            this.baseEnemyActionMachine.BaseEnemy.Direction = (this.baseEnemyActionMachine.NavMeshPath.corners[1] - this.baseEnemyActionMachine.transform.position).normalized;
        }
        // Debug.Log(this.baseEnemyActionMachine.transform.position);
        // Debug.Log(Vector3.Distance(this.baseEnemyActionMachine.transform.position, this.destination));
        if(Vector3.Distance(this.baseEnemyActionMachine.transform.position, this.destination) <= 2.2f){
            this.NextState();
        }
    }
    protected override void NextState() {
        base.NextState();
        base.baseEnemyActionMachine.ChangeState(this.baseEnemyActionMachine.IdleState);
    }
    public override void Exit() {
        base.Exit();
    }
}
