using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundController : MonoBehaviour
{
    public static SoundController instance;
    public AudioMixer vfxMixer;
    public AudioSource audioSource;
    public AudioClip onDmgClip;
    public AudioClip onCollected;
    public AudioClip onMonsterKill;

    private void Awake()
    {
        instance = this;
    }

    public void GetDmgSound()
    {
        audioSource.PlayOneShot(onDmgClip);
    }

    public void CollectingSound()
    {
        audioSource.PlayOneShot(onCollected);
    }

    public void MonsterKillSound()
    {
        audioSource.PlayOneShot(onMonsterKill);
    }
    public static void PlaySFX(AudioClip clip)
    {
        instance.audioSource.clip = clip;
        //jouer l'audio source de cette objet
        instance.audioSource.Play();
    }
}
