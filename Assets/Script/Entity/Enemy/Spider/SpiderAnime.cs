using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnime : BaseEnemyAnime {
    public virtual void Attack2() {
        base.baseEnemy.Animator.SetTrigger("attack2");
    }

    public virtual void Attack3() {
        base.baseEnemy.Animator.SetTrigger("attack3");
    }
    
    public virtual void attackEffect() {
        var tra = base.baseEnemy.EnemyVisionDetector.transform;
        var b = tra.rotation * Vector3.right * 3;
        GamingPoolGameObject AttackBox = GameController.getInstance.GetManager<GamePlayManager>().gamingPool.GetGameObject("AttackBox", tra.position + b, tra.rotation);
        AttackBox attackBox = (AttackBox)AttackBox;
        attackBox.setAttribute(new AttributePack(base.baseEnemy, 5, tra.rotation * Vector3.right));
    }
}
