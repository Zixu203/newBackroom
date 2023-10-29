using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : build
{
    public GameObject door;
    public bool is_open = false;
    public BoxCollider2D BoxCollider2D;
    protected override void Start()
    {
        door.SetActive(false);
    }
    protected override void Update()
    {

    }
    public override void BeenInteract()
    {
        is_open = !is_open;
        door.SetActive(is_open);
        BoxCollider2D.isTrigger = is_open;
    }
}
