using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curebag : BaseBuild
{
    // Start is called before the first frame update
    public GameObject curebag;
    //public BoxCollider2D KeyCollider2D;
    public override void BeenInteract() {
        this.gameObject.SetActive(false);
        GameController.getInstance.targetPlayer.Attribute.Heal(20);
        
        //GameController.getInstance.targetPlayer.have_door_key = true;
        //KeyCollider2D.isTrigger = false;
    }
}
