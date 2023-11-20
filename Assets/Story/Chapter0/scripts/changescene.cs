using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using UnityEngine.Video;
public class changescene : MonoBehaviour
{
    public VideoPlayer player;
    public PlayableDirector players;
    public void Start()
    {
        player.loopPointReached += (x) => { SceneManager.LoadScene("Storyscene"); };
    }
    private void Update()
    {
        if (!player.isPlaying)
            {
               //Debug.Log("change storyscenes");
               // SceneManager.LoadScene("Storyscene");
            }
    }
}
