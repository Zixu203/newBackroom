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
    protected override void Start() {
    }
    protected override void Update() {
        base.direction.x = Input.GetKey(this.actionCodes[0]) ? (Input.GetKey(this.actionCodes[1]) ? 0 : 1) : (Input.GetKey(this.actionCodes[1]) ? -1 : 0);
        base.direction.y = Input.GetKey(this.actionCodes[2]) ? (Input.GetKey(this.actionCodes[3]) ? 0 : 1) : (Input.GetKey(this.actionCodes[3]) ? -1 : 0);
        this.runSpeed = Input.GetKey(KeyCode.C) ? 5f : 1f;
        base.animator.SetInteger("xspeed", Convert.ToInt16(base.direction.x * this.runSpeed));
        base.animator.SetInteger("yspeed", Convert.ToInt16(base.direction.y * this.runSpeed));
        if(Input.GetKeyDown(this.actionCodes[0]) || Input.GetKeyDown(this.actionCodes[1]) || Input.GetKeyDown(this.actionCodes[2]) || Input.GetKeyDown(this.actionCodes[3])){
            base.animator.SetTrigger("walk");
        }
        if(Input.GetKeyDown(KeyCode.K)){
            this.ShuffleInput();
        }
        if(Input.GetKeyDown(KeyCode.T)){
            // this.slash.transform.position = this.gameObject.transform.position
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
        this.rigidBody2D.velocity = this.rigidBody2D.velocity * runSpeed;
    }
}
