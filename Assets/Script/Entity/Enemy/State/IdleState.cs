using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class IdleState : State {
    [SerializeField] protected IdleStateData idleStateData;
    protected float IdleTime;
    public IdleState(BaseEnemyActionMachine baseEnemyActionMachine) : base(baseEnemyActionMachine) {
    }
    public override void Init() {
        base.Init();
        this.IdleTime = UnityEngine.Random.Range(this.idleStateData.minIdleTime, this.idleStateData.maxIdleTime);
    }
    public override void Enter() {
        base.Enter();
        this.baseEnemyActionMachine.BaseEnemy.Direction = Vector2.zero;
    }
    public override void Update() {
        base.Update();
        if(Time.time - base.EnterTime > this.IdleTime) {
            this.NextState();
        }
    }
    protected override void NextState() {
        base.NextState();
        base.baseEnemyActionMachine.ChangeState(this.baseEnemyActionMachine.PatrolState);
    }
    public override void Exit() {
        base.Exit();
    }
}
