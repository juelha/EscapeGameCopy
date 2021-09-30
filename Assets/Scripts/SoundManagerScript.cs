using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
        public static AudioClip bgMusic, enemyAttack;

        private static AudioSource audioSrc;

        void Start()
        {
            bgMusic = Resources.Load<AudioClip>("Track E");
            enemyAttack = Resources.Load<AudioClip>("horror");
            audioSrc = GetComponent<AudioSource>();

            PlaySound("bg");
        }

        // Update is called once per frame
        void Update()
        {

        }

        public static void PlaySound(string clip)
        {
            switch (clip)
            {
                case "bg":
                    audioSrc.PlayOneShot(bgMusic, 0.5f);
                    
                    break;
                case "enemyAttack":
                    audioSrc.PlayOneShot(enemyAttack, 1f);
                    break;
            }
        }
}

