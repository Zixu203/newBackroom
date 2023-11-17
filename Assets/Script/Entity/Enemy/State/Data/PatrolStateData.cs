using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BasePatrolStateData", menuName = "StateData/PatrolStateData/BasePatrolStateData")]
public class PatrolStateData : ScriptableObject {
    public float minPatrolDistance = 2f;
    public float maxPatrolDistance = 5f;
}
