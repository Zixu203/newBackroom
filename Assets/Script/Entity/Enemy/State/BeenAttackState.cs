using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BeenAttackState : State {
    [SerializeField] BeenAttackStateData beenAttackStateData;
    public BeenAttackState(BaseEnemyActionMachine baseEnemyActionMachine) : base(baseEnemyActionMachine) {

    }
    public override void Init() {
        base.Init();
    }
    public override void Enter() {
        base.Enter();
    }
    public override void Update() {
        base.Update();
        if(Time.time - base.EnterTime > this.beenAttackStateData.hitStunTime) {
            this.NextState();
        }
    }
    protected override void NextState() {
        base.NextState();
        this.baseEnemyActionMachine.ChangeState(base.baseEnemyActionMachine.SearchState);
    }
    public override bool CheckChange(State state) {
        return false;
    }
    public override void Exit() {
        base.Exit();
    }
}
