using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State {
    [SerializeField] protected BaseEnemyActionMachine baseEnemyActionMachine;
    protected float EnterTime;
    public State(BaseEnemyActionMachine baseEnemyActionMachine) {
        this.baseEnemyActionMachine = baseEnemyActionMachine;
    }
    public virtual void Init() {
        this.EnterTime = Time.time;
    }
    public virtual void Enter() {
    }
    public virtual void Update() {
        
    }
    protected virtual void NextState() {
        
    }
    public virtual void Exit() {

    }
}
