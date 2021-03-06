using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{
   [SerializeField] private Button btn;
    [SerializeField]private Sprite mutedImg, unMutedImg;
    [SerializeField]private Image img;
   
    private void Awake()
    {
        //btn = GetComponent<Button>();
        img.sprite = mutedImg;

    }
   
    private void Start()
    {
        btn.onClick.AddListener(MuteControl);
        
    }
    private void Update()
    {
        if (SoundManager.Instance.isMuted)
        {
            img.sprite = unMutedImg;

        }
        else
        {
            img.sprite = mutedImg;
        }
    }
    private void MuteControl()
    {
        SoundManager.Instance.Mute();
       
    }
}
