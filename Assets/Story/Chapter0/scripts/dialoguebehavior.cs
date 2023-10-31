using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using TMPro;
// A behaviour that is attached to a playable
[System.Serializable]
public class dialoguebehavior : PlayableBehaviour
{
    private PlayableDirector playableDirector;
    [Header("¹ï¸Ü®Ø")]
    public ExposedReference<Transform> dialog;
    private Transform _dialog;
    [Multiline(3)]
    public string dialogstr;
    public override void OnPlayableCreate(Playable playable)
    {
        playableDirector = playable.GetGraph().GetResolver() as PlayableDirector;
    }
    // Called when the owning graph starts playing
    public override void OnGraphStart(Playable playable)
    {
        _dialog = dialog.Resolve(playable.GetGraph().GetResolver());
    }

    // Called when the state of the playable is set to Play
    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        _dialog.GetComponent<TextMeshProUGUI>().text = dialogstr;
    }

    // Called when the state of the playable is set to Paused
    public override void OnBehaviourPause(Playable playable, FrameData info)
    {
        _dialog.GetComponent<TextMeshProUGUI>().text = "";
    }

    // Called each frame while the state is set to Play
}
