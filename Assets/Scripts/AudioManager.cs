using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : TI3NMono
{
    private static AudioManager instance;
    public static AudioManager Instance => instance;
    [SerializeField] private AudioSource effectSource;
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip tapClip;
    [SerializeField] private AudioClip hurtClip;
    [SerializeField] private AudioClip crackEggClip;
    private bool hasPlayEffectSound = false;
    protected override void Awake()
    {
        if (AudioManager.instance != null) return;
        AudioManager.instance = this;

    }
    public bool HasPlayEffectSound()
    {
        return hasPlayEffectSound;
    }
    public void SetHasPlayEffectSound(bool value)
    {
        hasPlayEffectSound = value;
    }

    void Start()
    {
        effectSource.Stop();
        hasPlayEffectSound = true;
    }
    public void PlayJumpClip()
    {
        effectSource.PlayOneShot(jumpClip);
    }
    public void PlayTapClip()
    {
        effectSource.PlayOneShot(tapClip);
    }
    public void PlayHurtClip()
    {
        effectSource.PlayOneShot(hurtClip);
    }
    public void PlayCrackEggClip()
    {
        effectSource.PlayOneShot(crackEggClip);
    }
}
