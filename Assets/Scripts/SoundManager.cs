using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Plugins.Audio.Core;
using Plugins.Audio.Utils;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] private SourceAudio audioSource, musicSource;
    [SerializeField] AudioDataProperty musicClip;
    public float volume = 1;
    //private float volume = 1f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {

        musicSource.Play(musicClip);
    }

    public void PlaySound(AudioDataProperty clip)
    {
        audioSource.PlayOneShot(clip);
    }

    public void ChangeMasterVolume(float val)
    {
        volume = val;
        audioSource.Volume = val;
        musicSource.Volume = val;
        //AudioListener.volume = val;
    }
}
