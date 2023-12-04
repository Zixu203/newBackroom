using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SpiderChaseState : ChaseState {
    [SerializeField] protected SpiderChaseStateData spiderChaseStateData;
    public SpiderChaseState(BaseEnemyActionMachine baseEnemyActionMachine) : base(baseEnemyActionMachine) {
    }

    public override void Update() {
        base.Update();
        if(Vector3.Distance(this.baseEnemyActionMachine.transform.position, this.target) <= 4f){
            this.NextState();
        }
    }

    protected override void NextState() {
        int num = UnityEngine.Random.Range(0,3);
        Debug.Log(num);
        switch(num){
            case 0:
                this.baseEnemyActionMachine.ChangeState(this.baseEnemyActionMachine.AttackState);
                break;
            case 1:
                this.baseEnemyActionMachine.ChangeState((this.baseEnemyActionMachine as SpiderActionMachine).Attack2State);
                break;
            case 2:
                this.baseEnemyActionMachine.ChangeState((this.baseEnemyActionMachine as SpiderActionMachine).Attack3State);
                break;
            default:
                this.baseEnemyActionMachine.ChangeState(this.baseEnemyActionMachine.AttackState);
                break;

        }
    }
}
