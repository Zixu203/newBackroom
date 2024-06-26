using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Attack2State : State {
    [SerializeField] protected Attack2StateData attackStateData;
    protected Vector3 target;
    protected bool attacking = true;
    protected float AnimeLength;
    public Attack2State(BaseEnemyActionMachine baseEnemyActionMachine) : base(baseEnemyActionMachine) {
    }
    public override void Init() {
        base.Init();
        this.attacking = true;
        this.target = this.baseEnemyActionMachine.LastTargetPosition;
        this.AnimeLength = 2f;
        // AnimeLength = 0f; // get attack animation time
    }
    public override void Enter() {
        base.Enter();
        (this.baseEnemyActionMachine.BaseEnemy.BaseEnemyAnime as SpiderAnime).Attack2();
        // var tra = this.baseEnemyActionMachine.BaseEnemy.EnemyVisionDetector.transform;
        // var b = tra.rotation * Vector3.right * 4;
        // GamingPoolGameObject AttackBox = GameController.getInstance.GetManager<GamePlayManager>().gamingPool.GetGameObject("AttackBox", tra.position + b, tra.rotation);
        // AttackBox attackBox = (AttackBox)AttackBox;
        // attackBox.setAttribute(new AttributePack(this.baseEnemyActionMachine.BaseEnemy, 5, tra.rotation * Vector3.right));
        // bubble.GetComponent<SoundBubble>().Init(this, SoundBubble.SoundBubbleType.Normal, 10);
    }
    public override void Update() {
        base.Update();
        if(Time.time - base.EnterTime > this.AnimeLength) {
            this.NextState();
        }
    }
    protected override void NextState() {
        base.NextState();
        this.attacking = false;
        this.baseEnemyActionMachine.ChangeState(this.baseEnemyActionMachine.SearchState);
    }
    public override bool CheckChange(State state) {
        return !attacking || state is BeenAttackState || state is DeadState;
    }
    public override void Exit() {
        base.Exit();
    }
}
