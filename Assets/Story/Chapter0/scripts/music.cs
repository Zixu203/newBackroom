using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour
{
    public float fadeTime = 1;
    public AudioSource musics;
    public AudioClip a;
    public AudioClip b;
    public AudioClip c;
    public void playa()
    {
        musics.PlayOneShot(a);
    }
    public void playb()
    {
        musics.PlayOneShot(b);
    }
    public void playc()
    {
        musics.PlayOneShot(c);
    }
    public void FadeSound()
    {
        if (fadeTime == 0)
        {
            musics.volume = 0;
            return;
        }
        StartCoroutine("FadeSounds");
    }
    IEnumerator FadeSounds()
    {
        float t = fadeTime;
        while (t > 0)
        {
            yield return null;
            t -= Time.deltaTime;
           musics.volume = t / fadeTime;
        }
        yield break;
    }
}
