using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BaseIdleStateData", menuName = "StateData/IdleStateData/BaseIdleStateData")]
public class IdleStateData : ScriptableObject {
    public float minIdleTime = 3f;
    public float maxIdleTime = 7f;
}
