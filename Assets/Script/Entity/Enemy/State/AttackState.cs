using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AttackState : State {
    [SerializeField] protected AttackStateData attackStateData;

    public AttackState(BaseEnemyActionMachine baseEnemyActionMachine) : base(baseEnemyActionMachine)
    {
    }
}
