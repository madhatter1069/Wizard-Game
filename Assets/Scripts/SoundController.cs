using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioClip slimeDeath;
    public AudioClip skeletonDeath;
    public AudioClip spellCast;

    AudioSource audioSource;


    void Start()
    {
        slimeDeath = Resources.Load<AudioClip>("SlimePop");
        skeletonDeath = Resources.Load<AudioClip>("SkeletonDeath");
        spellCast = Resources.Load<AudioClip>("SpellCast");

        audioSource = GetComponent<AudioSource>();
    }


    void Update()
    {
        
    }

    public void PlaySound(string audioClip)
    {
        switch (audioClip)
        {
            case "SlimePop":
                audioSource.PlayOneShot(slimeDeath);
                break;

            case "SkeletonDeath":
                audioSource.PlayOneShot(skeletonDeath);
                break;

            case "SpellCast":
                audioSource.PlayOneShot(spellCast);
                break;
        }
    }
}
