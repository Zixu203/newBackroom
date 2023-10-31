using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour {
    public enum PlayerWeaponType {
        sword,
        gun
    }
    [SerializeField]
    private Player player;
    public Slash slash;
    public PlayerWeaponType playerWeaponType;
    public void switchWeapon(PlayerWeaponType playerWeaponType) {
        this.playerWeaponType = playerWeaponType;
    }
    public void Attack(Player.PlayerDirection playerDirection) {
        switch(this.playerWeaponType) {
            case PlayerWeaponType.sword:
                this.slashAttack(playerDirection);
                break;
            case PlayerWeaponType.gun:
                this.shootAttack(playerDirection);
                break;
            default:
                return;
        }
    }
    public void slashAttack(Player.PlayerDirection playerDirection) {
        this.slash.transform.position = this.player.transform.position + this.DirectionToForward(playerDirection) * 1.4f;
        this.slash.transform.rotation = quaternion.identity;
        this.slash.transform.Rotate(Vector3.forward, DiectionToRotate(playerDirection));
        this.slash.setAttribute(new AttributePack(this.player, 5));
        this.slash?.gameObject.SetActive(true);
        this.player.GetAnimator().SetBool("attacking", true);
        this.player.GetAnimator().SetTrigger("attack");
    }
    public void shootAttack(Player.PlayerDirection playerDirection) {
        this.player.GetAnimator().SetBool("attacking", true);
        this.player.GetAnimator().SetTrigger("shoot");
    }
    public void endAttack() {
        this.player.GetAnimator().SetBool("attacking", false);
    }
    private Vector3 DirectionToForward(Player.PlayerDirection playerDirection) {
        switch (playerDirection) {
            case Player.PlayerDirection.Up:
                return Vector3.up;
            case Player.PlayerDirection.Down:
                return Vector3.down;
            case Player.PlayerDirection.Left:
                return Vector3.left;
            case Player.PlayerDirection.Right:
                return Vector3.right;
            default:
                return Vector3.zero;
        }
    }
    private float DiectionToRotate(Player.PlayerDirection playerDirection) {
        switch (playerDirection) {
            case Player.PlayerDirection.Up:
                return 180f;
            case Player.PlayerDirection.Down:
                return 0f;
            case Player.PlayerDirection.Left:
                return 270f;
            case Player.PlayerDirection.Right:
                return 90f;
            default:
                return 0f;
        }
    }
}
