using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WalkState : State {
    [SerializeField] protected WalkStateData walkStateData;
    public WalkState(BaseEnemyActionMachine baseEnemyActionMachine) : base(baseEnemyActionMachine) {
    }
}
