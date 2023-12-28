using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : SingletonHandler<SoundManager>
{
    [SerializeField][Range(0f, 1f)] private float soundEffectVolume;
    [SerializeField][Range(0f, 1f)] private float soundEffectPitchVariance;
    [SerializeField][Range(0f, 1f)] private float musicVolume;
    private ObjectPool objectPool;

    private AudioSource musicAudioSource;
    public AudioClip musicClip;

    protected override void Awake()
    {
        base.Awake();
        musicAudioSource = GetComponent<AudioSource>();
        musicAudioSource.volume = musicVolume;
        musicAudioSource.loop = true;

        objectPool = GetComponent<ObjectPool>();
    }

    private void Start()
    {
        ChangeBackGroundMusic(musicClip);
    }

    public static void ChangeBackGroundMusic(AudioClip music)
    {
        Instance.musicAudioSource.Stop();
        Instance.musicAudioSource.clip = music;
        Instance.musicAudioSource.Play();
    }

    public static void PlayClip(AudioClip clip)
    {
        GameObject obj = Instance.objectPool.SpawnFromPool("SoundSource");
        obj.SetActive(true);
        SoundSource soundSource = obj.GetComponent<SoundSource>();
        soundSource.Play(clip, Instance.soundEffectVolume, Instance.soundEffectPitchVariance);
    }
}
