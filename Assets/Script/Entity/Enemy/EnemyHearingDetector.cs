using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyHearingDetector : TriggerDetector<BaseEnemy, SoundBubble> {
    public override void OnTriggerEnterAction(SoundBubble obj) {
        base.OnTriggerEnterAction(obj);
    }
    public override void OnTriggerExitAction(SoundBubble obj) {
        base.OnTriggerExitAction(obj);
    }
}
