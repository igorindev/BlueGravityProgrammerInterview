using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] AudioUIButtons audioUIButtons;
    AudioSource m_AudioSource;

    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio2D(AudioClip clip)
    {
        if (clip)
        {
            m_AudioSource.PlayOneShot(clip);
        }
        else
        {
            Debug.LogWarning("Audio Clip is null");
        }
    }

    public void PlayButtonAudio(AudioUIButtons.ButtonClick audioType)
    {
        audioUIButtons.PlayButtonClickAudio(audioType);
    }
}
