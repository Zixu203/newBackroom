using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyVisionDetector : TriggerDetector<BaseEnemy, CombatableEntity> {
    public void lookAt(Transform target) {
        this.transform.rotation = Quaternion.FromToRotation(Vector3.right, target.position - this.transform.position);
    }
    public override void OnTriggerEnterAction(CombatableEntity obj) {
        base.OnTriggerEnterAction(obj);
    }
    public override void OnTriggerExitAction(CombatableEntity obj) {
        base.OnTriggerExitAction(obj);
    }
}
