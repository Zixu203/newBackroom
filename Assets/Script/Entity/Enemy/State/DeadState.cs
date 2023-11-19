using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DeadState : State {
    [SerializeField] DeadStateData deadStateData;
    public DeadState(BaseEnemyActionMachine baseEnemyActionMachine) : base(baseEnemyActionMachine) {

    }
    public override void Init() {
        base.Init();
    }
    public override void Enter() {
        base.Enter();
    }
    public override void Update() {
        base.Update();
    }
    protected override void NextState() {
        base.NextState();
    }
    public override void Exit() {
        base.Exit();
    }
}
