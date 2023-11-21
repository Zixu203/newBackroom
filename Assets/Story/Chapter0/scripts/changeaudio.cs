using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeaudio : MonoBehaviour
{
    private static int count = 0;
    public AudioClip audio;
    public AudioClip audios;
    public AudioSource audioplayer;
    // Start is called before the first frame update
    private void Start()
    {
        audioplayer = GetComponent<AudioSource>();
        if (count == 0)
        {
            count++;
            audioplayer.PlayOneShot(audio);
        }
        else
            audioplayer.PlayOneShot(audios);
    }
    public void LowerSound()
    {
        StartCoroutine("FadeSound");
    }
    IEnumerator FadeSound()
    {
        float t = 1;
        while (t > 0)
        {
            yield return null;
            t -= Time.deltaTime;
            audioplayer.volume = t;
        }
        yield break;
    }
}
