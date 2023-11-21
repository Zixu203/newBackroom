using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WalkState : State {
    [SerializeField] protected WalkStateData walkStateData;
    public WalkState(BaseEnemyActionMachine baseEnemyActionMachine) : base(baseEnemyActionMachine) {
    }
    protected Vector3 destination;

    public override void Init() {
        base.Init();
        this.destination = this.baseEnemyActionMachine.LastTargetPosition;
    }
    public override void Enter() {
        base.Enter();
    }
    public override void Update() {
        base.Update();
        bool isRoadFound = this.baseEnemyActionMachine.BaseEnemy.NavMeshAgent.CalculatePath(this.destination, this.baseEnemyActionMachine.NavMeshPath);
        if(isRoadFound) {
            this.baseEnemyActionMachine.BaseEnemy.Direction = (this.baseEnemyActionMachine.NavMeshPath.corners[1] - this.baseEnemyActionMachine.transform.position).normalized;
            this.baseEnemyActionMachine.BaseEnemy.EnemyVisionDetector.lookAt(this.baseEnemyActionMachine.NavMeshPath.corners[1]);
        }
        if(Vector2.Distance(this.baseEnemyActionMachine.BaseEnemy.transform.position, this.destination) <= 1f){
            this.NextState();
        }
    }
    protected override void NextState() {
        base.NextState();
        this.baseEnemyActionMachine.ChangeState(this.baseEnemyActionMachine.SearchState);
    }
    public override void Exit() {
        base.Exit();
    }
}
