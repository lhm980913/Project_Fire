using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public enum AudioType
    {
        Attack,
        Walk,
        Slide,
        Ground,
        Jump,
        Defence,
        AttackEnemy
    }
    [Serializable]
    struct AudioAndType
    {
        public AudioType type;
        public AudioClip audioClip;
    }
    static private AudioManager instance;
    static public AudioManager Instance
    {
        get
        {
            return instance;
        }
    }

    [SerializeField]
    private List<AudioAndType> audios;

    private Dictionary<AudioType, AudioClip> AudioDictionary;
    private AudioSource audioSource;
    void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
        InitAudioDictionary();
    }

    void InitAudioDictionary()
    {
        AudioDictionary = new Dictionary<AudioType, AudioClip>();
        foreach (var audio in audios)
        {
            AudioDictionary.Add(audio.type, audio.audioClip);
        }
    }

    public void TryPlayAudio(AudioType type)
    {
        AudioClip temp;
        if(AudioDictionary.TryGetValue(type,out temp))
        {
            audioSource.PlayOneShot(temp);
        }
        else
        {
            Debug.Log(type.ToString());
        }
    }
}
