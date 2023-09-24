using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : BaseEntity {
    [SerializeField]
    protected float runSpeed;
    protected float runDirection;
    List<KeyCode> actionCodes;
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
    protected override void Start() {
    }
    protected override void Update() {
        base.direction.x = Input.GetKey(this.actionCodes[0]) ? (Input.GetKey(this.actionCodes[1]) ? 0 : 1) : (Input.GetKey(this.actionCodes[1]) ? -1 : 0);
        base.direction.y = Input.GetKey(this.actionCodes[2]) ? (Input.GetKey(this.actionCodes[3]) ? 0 : 1) : (Input.GetKey(this.actionCodes[3]) ? -1 : 0);
        this.runSpeed = Input.GetKey(KeyCode.C) ? 5f : 1f;
        if(Input.GetKeyDown(KeyCode.K)){
            this.ShuffleInput();
        }
    }
    protected override void FixedUpdate() {
        base.FixedUpdate();
        this.rigidBody2D.velocity = this.rigidBody2D.velocity * runSpeed;
    }
}