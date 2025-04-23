using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public List<AudioSource> sfxSources = new List<AudioSource>();

    private void Awake()
    {
        
    }
}
