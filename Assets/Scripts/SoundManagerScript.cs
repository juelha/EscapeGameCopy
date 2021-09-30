using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
        public static AudioClip bgMusic;

        private static AudioSource audioSrc;

        void Start()
        {
            bgMusic = Resources.Load<AudioClip>("Track E");

            audioSrc = GetComponent<AudioSource>();

            PlaySound();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public static void PlaySound()
        {
            audioSrc.PlayOneShot(bgMusic, 0.5f);
        }
}

