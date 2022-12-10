using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static UnityEngine.Rendering.DebugUI;

public class SoundManager : MonoBehaviour
{
    private const string keyVolume = "volume";
    private const string keyEffects = "effects";
    private const string keyMusic = "music";
    public static SoundManager instance;
    [Header("AudioSources")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource effectSource;

    [SerializeField] [Range(0f,100f)] private float volume;
    [SerializeField] private bool effects;
    [SerializeField] private bool music;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        InitializeVolumes();
    }

    private void OnValidate()
    {
        ChangeMasterVolume(volume);
        effectSource.mute = effects;
        musicSource.mute = music;
    }


    private void InitializeVolumes()
    {
        if (!PlayerPrefs.HasKey(keyVolume))
        {
            PlayerPrefs.SetFloat(keyVolume, 100);
        }
        ChangeMasterVolume(PlayerPrefs.GetFloat(keyVolume));

        if (!PlayerPrefs.HasKey(keyEffects))
        {
            PlayerPrefs.SetInt(keyEffects, 1);
        }
        effectSource.mute = false;

        if (!PlayerPrefs.HasKey(keyMusic))
        {
            PlayerPrefs.SetInt(keyMusic, 1);
        }
        musicSource.mute = false;
    }

    public void PlaySound(AudioClip clip, float volume = 1)
    {
        effectSource.PlayOneShot(clip,volume);
    }
    public void PlaySoundAtPoint(AudioClip clip, Vector3 position, float volume = 1)
    {
        AudioSource.PlayClipAtPoint(clip, position, volume);
    }
    public void ChangeMasterVolume(float value)
    {
        AudioListener.volume = 100;
        PlayerPrefs.SetFloat(keyVolume, value);

    }

    public void PlayMusic(AudioClip clip)
    {
        if(musicSource.isPlaying)
            musicSource.Stop();
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void ToggleEffects()
    {
        effectSource.mute = !effectSource.mute;
        PlayerPrefs.SetInt(keyEffects, effectSource.mute ? 1 : 0);

    }
    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
        PlayerPrefs.SetInt(keyMusic, effectSource.mute ? 1 : 0);


    }

    internal void StopSound()
    {
        if (effectSource.isPlaying)
            effectSource.Stop();
    }
}
