using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource clickingUISound;
    public static SoundManager instance;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        
    }

    public void UIClickSound()
    {
        clickingUISound.Play();
    }
}
