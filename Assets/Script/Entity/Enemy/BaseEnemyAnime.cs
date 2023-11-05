using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyAnime : MonoBehaviour {
    [SerializeField] protected BaseEnemy baseEnemy;
    void Start() {
        
    }
    public void Update() {
        this.baseEnemy.Animator.SetFloat("x", this.baseEnemy.Direction.x);
        this.baseEnemy.Animator.SetBool("walk", this.baseEnemy.Direction.x != 0);
    }
    
    public virtual void BeenAttack() {
        this.baseEnemy.Animator.SetTrigger("beenAttack");
    }

    public virtual void Die() {
        this.baseEnemy.Animator.SetTrigger("die");
    }

    public void OnDeadAnime() {
        this.baseEnemy.BaseEnemyActionMachine.Dead();
    }
}
