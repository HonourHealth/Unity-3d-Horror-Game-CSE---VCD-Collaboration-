using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance = null;

    public AudioClip hoho;
    public AudioClip finish;
    public AudioClip monster_is_coming;
    public AudioClip scream;

    private AudioSource soundEffectAudio;

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);

        }

        AudioSource theSource = GetComponent<AudioSource>();
        soundEffectAudio = theSource;

    }

    public void PlayOneShot(AudioClip clip)
    {
        soundEffectAudio.PlayOneShot(clip);
    }
}