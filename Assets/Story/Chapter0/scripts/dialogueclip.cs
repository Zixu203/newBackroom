using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[System.Serializable]
public class dialogueclip : PlayableAsset
{
    public dialoguebehavior template = new dialoguebehavior();
    // Factory method that generates a playable based on this asset
    public override Playable CreatePlayable(PlayableGraph graph, GameObject go)
    {
        var playable = ScriptPlayable<dialoguebehavior>.Create(graph, template);
        return playable;
    }
}
