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
        bgMusic = Resources.Load<AudioClip>("Track E");
        enemyAttack = Resources.Load<AudioClip>("horror");
        AudioSrc = GetComponent<AudioSource>();
        PlaySound("bg");
    }
    
    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "bg":
                AudioSrc.PlayOneShot(bgMusic, 0.5f);

                break;
            case "enemyAttack":
                AudioSrc.PlayOneShot(enemyAttack, 1f);
                break;
        }
    }
}
