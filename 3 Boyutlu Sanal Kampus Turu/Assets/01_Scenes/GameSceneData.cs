using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneData : MonoBehaviour
{
    [SerializeField] private AudioClip ambienceMusic;

    private void Awake()
    {
        SoundManager.Instance.PlayBGMusic(ambienceMusic);
    }
}
