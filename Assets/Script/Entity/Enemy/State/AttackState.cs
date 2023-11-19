using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AttackState : State {
    [SerializeField] protected AttackStateData attackStateData;
    protected Vector3 target;
    protected bool attacking = true;
    protected float AnimeLength;
    public AttackState(BaseEnemyActionMachine baseEnemyActionMachine) : base(baseEnemyActionMachine) {
    }
    public override void Init() {
        base.Init();
        this.attacking = true;
        this.target = this.baseEnemyActionMachine.LastTargetPosition;
        this.AnimeLength = 2f;
        // AnimeLength = 0f; // get attack animation time
    }
    public override void Enter() {
        base.Enter();
        this.baseEnemyActionMachine.BaseEnemy.BaseEnemyAnime.Attack();
    }
    public override void Update() {
        base.Update();
        if(Time.time - base.EnterTime > this.AnimeLength) {
            this.NextState();
        }
    }
    protected override void NextState() {
        base.NextState();
        this.attacking = false;
        this.baseEnemyActionMachine.ChangeState(this.baseEnemyActionMachine.SearchState);
    }
    public override bool CheckChange(State state) {
        return !attacking;
    }
    public override void Exit() {
        base.Exit();
    }
}
