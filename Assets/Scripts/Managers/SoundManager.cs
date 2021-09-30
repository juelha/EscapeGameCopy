using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip BgMusic;
    private static AudioSource AudioSrc;
    // Start is called before the first frame update
    void Start()
    {
        BgMusic = Resources.Load<AudioClip>("Track E"); 
        AudioSrc = GetComponent<AudioSource>();
        PlaySound();
    }
    
    public static void PlaySound()
    {
        AudioSrc.PlayOneShot(BgMusic, 0.5f);
    }
}
