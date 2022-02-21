using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TanitimSesleriManager : MonoBehaviour
{
    private static TanitimSesleriManager instance;
    private AudioSource source;

    public static TanitimSesleriManager Instance
    {
        get{ return instance; }
    }

    private void Awake()
    {
        instance = this;

    }
    public void Play(AudioClip bgMusic)
    {
        if (source != null && bgMusic != null)
        {
            source.clip = bgMusic;
            source.Play();

        }
    }
}
