using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BaseSearchStateData", menuName = "StateData/SearchStateData/BaseSearchStateData")]
public class SearchStateData : ScriptableObject {
    public float searchTime = 2f;
    public float searchSpeed = 180f;
}
