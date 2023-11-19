using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyVisionDetector : TriggerDetector<BaseEnemy, CombatableEntity> {
    public void lookAt(Transform target) {
        this.lookAt(target.position);
    }
    public void lookAt(Vector3 target) {
        this.transform.rotation = Quaternion.FromToRotation(Vector3.right, new Vector3(target.x, target.y, 0) - this.transform.position);
    }
    public void Rotate(float angle) {
        this.transform.Rotate(Vector3.forward, angle);
    }
    public override void OnTriggerEnterAction(CombatableEntity obj) {
        base.OnTriggerEnterAction(obj);
    }
    public override void OnTriggerExitAction(CombatableEntity obj) {
        base.OnTriggerExitAction(obj);
    }
}
