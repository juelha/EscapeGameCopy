using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip bgMusic, enemyAttack;
    private static AudioSource AudioSrc;
    // Start is called before the first frame update
    void Start()
    {
        // load both audio clips and get the audio source
        bgMusic = Resources.Load<AudioClip>("Track E");
        enemyAttack = Resources.Load<AudioClip>("horror");
        AudioSrc = GetComponent<AudioSource>();
        // play the background music at the start
        PlaySound("bg");
    }
    
    public static void PlaySound(string clip)
    {
        // check which audio clip should be played via the 
        switch (clip)
        {
            // play the background music
            case "bg":
                AudioSrc.PlayOneShot(bgMusic, 0.5f);
                break;
            // play the attack music
            case "enemyAttack":
                AudioSrc.PlayOneShot(enemyAttack, 1f);
                break;
        }
    }
}
