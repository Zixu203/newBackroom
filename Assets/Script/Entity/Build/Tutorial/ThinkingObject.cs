using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThinkingObject : InteractableEntity
{
    public GameObject Object;
    public BaseNPC npc;
    public override void OnInteractIn()
    {
        npc.BeenInteract();
        Object.SetActive(false);
        base.OnInteractIn();
    }
}
