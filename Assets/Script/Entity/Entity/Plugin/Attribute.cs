using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attribute {
    //Static Attr
    public double maxHp { get; private set; }
    public double hp { get; private set; }
    public double maxStrength { get; private set; }
    public double strength { get; private set; }
    public double san { get; private set; }
    public double power { get; private set; }
    public double defence { get; private set; }

    //Dynamic Attr
    public double damageReduce {get; private set;}

    //event

    public Action OnDead;
    public Action OnBeenAttack;

    public Attribute() {

    }
    public Attribute(double maxHp, double maxStrength, double san, double power, double defence) {
        this.maxHp = maxHp;
        this.hp = maxHp;
        this.maxStrength = maxStrength;
        this.strength = maxStrength;
        this.san = san;
        this.power = power;
        this.defence = defence;
    }
    void calcNewValue() {

    }
    public void Damage(double damage) {
        this.hp = Math.Clamp(this.hp - damage, 0, this.maxHp);
        if(this.IsDead()) this.OnDead?.Invoke();
        else this.OnBeenAttack?.Invoke();
    }
    public void Heal(double heal) {
        this.hp = Math.Clamp(this.hp + heal, 0, this.maxHp);
    }
    public bool IsDead() {
        return this.hp <= 0;
    }
}
