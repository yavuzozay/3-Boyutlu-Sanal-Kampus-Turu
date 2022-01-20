using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoSingleton<SoundManager>
{
    private AudioSource bgAudioSource;
    private bool _isMuted = false;
    public bool isMuted
    {
        get { return _isMuted; }
    }
    private void Awake()
    {
        base.Awake();
       // DontDestroyOnLoad(this);
        bgAudioSource = gameObject.AddComponent<AudioSource>();
        //bgAudioSource = GetComponent<AudioSource>();
        bgAudioSource.playOnAwake = true;
        bgAudioSource.loop = true;
    }
   
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            Mute();
        }
    }
    public void PlayBGMusic(AudioClip bgMusic)
    {
        if(bgAudioSource!=null&&bgMusic!=null)
        {
            bgAudioSource.clip = bgMusic;
            bgAudioSource.Play();
            
        }
    }
  
    public void Mute()
    {
        bgAudioSource.mute = !bgAudioSource.mute;
        _isMuted = bgAudioSource.mute;
       
    }
}
