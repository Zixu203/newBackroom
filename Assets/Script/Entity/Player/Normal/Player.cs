using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

public class Player : CombatableEntity {
    public bool have_door_key;
    public enum PlayerDirection {
        Up,
        Down,
        Left,
        Right
    }
    [SerializeField]
    protected float runSpeed;
    protected float calcRunSpeed;
    protected float runDirection;
    protected PlayerDirection playerDirection;
    [SerializeField]
    protected PlayerWeapon playerWeapon;
    List<KeyCode> actionCodes;
    [SerializeField]
    private Interactor interactor;
    public bool isInDialogue;

    public Player(){
        this.actionReset();
    }
    public void Init() {
        this.attribute = new Attribute(10, 2, 1, 2, 2);
    }
    public Animator GetAnimator() {
        return base.animator;
    }
    private void actionReset() {
        actionCodes = new List<KeyCode>() {
            KeyCode.D,
            KeyCode.A,
            KeyCode.W,
            KeyCode.S,
        };
    }
    public void ShuffleInput() {
        KeyCode keyCode;
        int other;
        System.Random random = new System.Random();
        for( int i = 0; i < actionCodes.Count(); ++i ) {
            other = random.Next(0, actionCodes.Count());
            keyCode = actionCodes[i];
            actionCodes[i] = actionCodes[other];
            actionCodes[other] = keyCode;
        }
    }
    protected override void Start() {
        this.Init();
    }
    protected override void Update() {
        if(GameController.getInstance.targetPlayer.isInDialogue){
            if(Input.GetKeyDown(KeyCode.Mouse0)){
                GameController.getInstance.dialogueSystem.ClickAction?.Invoke();
            }
            return;
        }
        PlayerDirection lastPlayerState = this.playerDirection;
        base.direction.x = Input.GetKey(this.actionCodes[0]) ? (Input.GetKey(this.actionCodes[1]) ? 0 : 1) : (Input.GetKey(this.actionCodes[1]) ? -1 : 0);
        base.direction.y = Input.GetKey(this.actionCodes[2]) ? (Input.GetKey(this.actionCodes[3]) ? 0 : 1) : (Input.GetKey(this.actionCodes[3]) ? -1 : 0);
        this.calcRunSpeed = Input.GetKey(KeyCode.C) ? this.runSpeed : 1f;
        base.animator.SetInteger("xspeed", Convert.ToInt16(math.sign(base.direction.x) * math.ceil(math.abs(base.direction.x * this.calcRunSpeed))));
        base.animator.SetInteger("yspeed", Convert.ToInt16(math.sign(base.direction.y) * math.ceil(math.abs(base.direction.y * this.calcRunSpeed))));
        this.playerDirection = Input.GetKey(this.actionCodes[0]) ? (Input.GetKey(this.actionCodes[1]) ? this.playerDirection : PlayerDirection.Right) : (Input.GetKey(this.actionCodes[1]) ? PlayerDirection.Left : this.playerDirection);
        this.playerDirection = Input.GetKey(this.actionCodes[2]) ? (Input.GetKey(this.actionCodes[3]) ? this.playerDirection : PlayerDirection.Up) : (Input.GetKey(this.actionCodes[3]) ? PlayerDirection.Down : this.playerDirection);
        bool actionKeyDown = this.actionCodes.Any(x => Input.GetKeyDown(x));
        bool actionKey = this.actionCodes.Any(x=>Input.GetKey(x));
        bool actionKeyUp = this.actionCodes.Any(x=>Input.GetKeyUp(x));
        if(actionKeyDown || (lastPlayerState != this.playerDirection)){
            base.animator.SetTrigger("walk");
        }
        if(Input.GetKeyDown(KeyCode.K)){
            this.ShuffleInput();
        }
        if(Input.GetKeyDown(KeyCode.T)){
            this.playerWeapon.slashAttack(this.playerDirection);
        }
        if(Input.GetKeyDown(KeyCode.Y)){
            this.playerWeapon.shootAttack(this.playerDirection);
        }
        if(Input.GetKeyDown(KeyCode.F)){
            this.interactor?.Interact();
        }
        if(Input.GetKeyDown(KeyCode.R)){
            this.interactor?.InteractAll();
        }
        if(Input.GetKeyDown(KeyCode.O)) {
            GameObject bubble = GameController.getInstance.gamingPool.GetGameObject("SoundBubble", this.gameObject.transform.position, quaternion.identity);
            bubble.GetComponent<SoundBubble>().Init(this, SoundBubble.SoundBubbleType.Normal, 10);
        }
        if(Input.GetKeyDown(KeyCode.Escape)){
            GameController.getInstance.inGameUIController.openSetting();
        }

        // Trigger Test Event
        //if(Input.GetKeyDown(KeyCode.V))
        //{
        //    GameController.getInstance.inGameUIController.pushInKnapsack("key");
        //}
        if (Input.GetKeyDown(KeyCode.B))
        {
            GameController.getInstance.inGameUIController.popOutKnapsack("key");
        }

    }
    protected override void FixedUpdate() {
        base.FixedUpdate();
        this.rigidBody2D.velocity *= this.calcRunSpeed;
    }
}
