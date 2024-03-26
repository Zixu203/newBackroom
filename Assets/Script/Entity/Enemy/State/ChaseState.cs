using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ChaseState : State {
    [SerializeField] protected ChaseStateData chaseStateData;
    protected Vector3 target;

    public ChaseState(BaseEnemyActionMachine baseEnemyActionMachine) : base(baseEnemyActionMachine) {
    }
    public override void Init() {
        base.Init();
        this.target = this.baseEnemyActionMachine.LastTargetPosition;
        this.baseEnemyActionMachine.BaseEnemy.MoveSpeedMultiplier = this.chaseStateData.chaseSpeed;
    }
    public override void Enter() {
        base.Enter();
    }
    public override void Update() {
        base.Update();
        bool isRoadFound = this.baseEnemyActionMachine.BaseEnemy.NavMeshAgent.CalculatePath(this.target, this.baseEnemyActionMachine.NavMeshPath);
        if(isRoadFound) {
            this.baseEnemyActionMachine.BaseEnemy.Direction = (this.baseEnemyActionMachine.NavMeshPath.corners[1] - this.baseEnemyActionMachine.transform.position).normalized;
            this.baseEnemyActionMachine.BaseEnemy.EnemyVisionDetector.lookAt(this.baseEnemyActionMachine.NavMeshPath.corners[1]);
        }
        if(Vector3.Distance(this.baseEnemyActionMachine.transform.position, this.target) <= 2f){
            this.NextState();
        }
    }
    protected override void NextState() {
        base.NextState();
        this.baseEnemyActionMachine.ChangeState(this.baseEnemyActionMachine.AttackState);
    }
    public override void Exit() {
        this.baseEnemyActionMachine.BaseEnemy.MoveSpeedMultiplier = 1f;
        base.Exit();
    }
}
