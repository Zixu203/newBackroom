using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioplay : MonoBehaviour
{
    public AudioClip audio;
    public AudioSource audioplayer;
    // Start is called before the first frame update
    void Start()
    {
        audioplayer = GetComponent<AudioSource>();
        audioplayer.PlayOneShot(audio);
    }
}
