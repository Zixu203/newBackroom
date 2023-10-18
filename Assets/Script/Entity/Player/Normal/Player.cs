using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

public class Player : BaseEntity {
    protected enum PlayerDirection {
        Up,
        Down,
        Left,
        Right
    }
    [SerializeField]
    protected float runSpeed;
    protected float runMulti;
    protected float runDirection;
    protected PlayerDirection playerDirection;
    List<KeyCode> actionCodes;
    public GameObject slash;
    
    [SerializeField]
    private Interactor interactor;

    public Player(){
        this.actionReset();
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
    private Vector3 DirectionToForward(PlayerDirection playerDirection) {
        switch (playerDirection) {
            case PlayerDirection.Up:
                return Vector3.up;
            case PlayerDirection.Down:
                return Vector3.down;
            case PlayerDirection.Left:
                return Vector3.left;
            case PlayerDirection.Right:
                return Vector3.right;
            default:
                return Vector3.zero;
        }
    }
    private float DiectionToRotate(PlayerDirection playerDirection) {
        switch (playerDirection) {
            case PlayerDirection.Up:
                return 180f;
            case PlayerDirection.Down:
                return 0f;
            case PlayerDirection.Left:
                return 270f;
            case PlayerDirection.Right:
                return 90f;
            default:
                return 0f;
        }
    }
    protected override void Start() {
    }
    protected override void Update() {
        PlayerDirection lastPlayerState = this.playerDirection;
        base.direction.x = Input.GetKey(this.actionCodes[0]) ? (Input.GetKey(this.actionCodes[1]) ? 0 : 1) : (Input.GetKey(this.actionCodes[1]) ? -1 : 0);
        base.direction.y = Input.GetKey(this.actionCodes[2]) ? (Input.GetKey(this.actionCodes[3]) ? 0 : 1) : (Input.GetKey(this.actionCodes[3]) ? -1 : 0);
        this.playerDirection = Input.GetKey(this.actionCodes[0]) ? (Input.GetKey(this.actionCodes[1]) ? this.playerDirection : PlayerDirection.Right) : (Input.GetKey(this.actionCodes[1]) ? PlayerDirection.Left : this.playerDirection);
        this.playerDirection = Input.GetKey(this.actionCodes[2]) ? (Input.GetKey(this.actionCodes[3]) ? this.playerDirection : PlayerDirection.Up) : (Input.GetKey(this.actionCodes[3]) ? PlayerDirection.Down : this.playerDirection);
        this.runMulti = Input.GetKey(KeyCode.C) ? this.runSpeed : 1f;
        base.animator.SetInteger("xspeed", Convert.ToInt16(math.sign(base.direction.x) * math.ceil(this.runMulti)));
        base.animator.SetInteger("yspeed", Convert.ToInt16(math.sign(base.direction.y) * math.ceil(this.runMulti)));
        bool actionKeyDown = this.actionCodes.Any(x => Input.GetKeyDown(x));
        bool actionKey = this.actionCodes.Any(x=>Input.GetKey(x));
        bool actionKeyUp = this.actionCodes.Any(x=>Input.GetKeyUp(x));
        // if(actionKeyDown || ( actionKey && actionKeyUp)){
        //     base.animator.SetTrigger("walk");
        // }
        if(actionKeyDown || (lastPlayerState != this.playerDirection)){
            base.animator.SetTrigger("walk");
        }
        if(Input.GetKeyDown(KeyCode.K)){
            this.ShuffleInput();
        }
        if(Input.GetKeyDown(KeyCode.T)){
            this.slash.transform.position = this.gameObject.transform.position + this.DirectionToForward(this.playerDirection) * 0.2f;
            this.slash.transform.rotation = quaternion.identity;
            this.slash.transform.Rotate(Vector3.forward, DiectionToRotate(this.playerDirection));
            this.slash?.SetActive(true);
            base.animator.SetTrigger("attack");
        }
        if(Input.GetKeyDown(KeyCode.F)){
            this.interactor?.Interact();
        }
        if(Input.GetKeyDown(KeyCode.R)){
            this.interactor?.InteractAll();
        }
    }
    protected override void FixedUpdate() {
        base.FixedUpdate();
        this.rigidBody2D.velocity = this.rigidBody2D.velocity * this.runMulti;
    }
}
