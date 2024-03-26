using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderActionMachine : BaseEnemyActionMachine {
    [SerializeField] Attack2State attack2State;
    public Attack2State Attack2State { get { return this.attack2State; } }

    [SerializeField] Attack3State attack3State;
    public Attack3State Attack3State { get { return this.attack3State; } }

    [SerializeField] SpiderChaseState spiderChaseState;
    public SpiderChaseState SpiderChaseState { get { return this.spiderChaseState; } }


    public override void Start() {
        base.Start();
        base.ChaseState = this.spiderChaseState;
    }
}
