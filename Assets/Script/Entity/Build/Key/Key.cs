using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : BaseBuild
{
    // Start is called before the first frame update
    public GameObject key;
    //public BoxCollider2D KeyCollider2D;
    public override void BeenInteract()
    {
        this.gameObject.SetActive(false);
        
        GameController.getInstance.targetPlayer.have_door_key = true;
        //KeyCollider2D.isTrigger = false;
    }
}
