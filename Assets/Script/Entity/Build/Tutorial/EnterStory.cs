using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterStory : InteractableEntity
{
    public override void OnInteractIn()
    {
        SceneManager.LoadScene("newScenes");
        base.OnInteractIn();
    }
}
