using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SearchState : State {
    [SerializeField] SearchStateData searchStateData;
    public SearchState(BaseEnemyActionMachine baseEnemyActionMachine) : base(baseEnemyActionMachine) {
    }

    public override void Init() {
        base.Init();
    }
    public override void Enter() {
        base.Enter();
    }
    public override void Update() {
        base.Update();
        this.baseEnemyActionMachine.BaseEnemy.EnemyVisionDetector.Rotate(this.searchStateData.searchSpeed * Time.deltaTime);
        if(Time.time - base.EnterTime > this.searchStateData.searchTime){
            this.NextState();
        }
    }
    protected override void NextState() {
        base.NextState();
        this.baseEnemyActionMachine.ChangeState(this.baseEnemyActionMachine.IdleState);
    }
    public override void Exit() {
        base.Exit();
    }
}
