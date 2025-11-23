using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public List<AudioSource> sfxSources = new List<AudioSource>();

    private Coroutine fadeCoroutine;

    private void Awake()
    {
        musicSource = transform.Find("MusicSource").GetComponent<AudioSource>();
        foreach (Transform child in transform)
        {
            if (child.name.StartsWith("SFXSource"))
            {
                AudioSource src = child.GetComponent<AudioSource>();
                if (src != null)
                {
                    sfxSources.Add(src);
                }
            }
        }
    }

    public void HardStopMusic() => musicSource.Stop();

    public void HardPlayMusic() => musicSource.Play();

    public void FadePlayMusic(AudioClip clip, float fadeDuration = 1f, bool loop = true)
    {
        if (clip == null)
        {
            Debug.LogWarning("Tried to play null music clip.");
            return;
        }

        // Stop ongoing fade if any
        if (fadeCoroutine != null)
            StopCoroutine(fadeCoroutine);

        fadeCoroutine = StartCoroutine(FadeInMusicCoroutine(clip, fadeDuration, loop));
    }

    public void FadeStopMusic(float fadeDuration = 1f)
    {
        if (fadeCoroutine != null)
            StopCoroutine(fadeCoroutine);

        fadeCoroutine = StartCoroutine(FadeOutMusicCoroutine(fadeDuration));
    }

    public void PlaySFX(AudioClip clip, float volume = 1f)
    {
        if (clip == null)
        {
            Debug.LogWarning("Tried to play null SFX clip.");
            return;
        }

        // Find the first available AudioSource
        foreach (AudioSource source in sfxSources)
        {
            if (!source.isPlaying)
            {
                source.clip = clip;
                source.volume = volume;
                source.Play();
                return;
            }
        }

        // If all are busy, use the first one forcefully
        Debug.LogWarning("All SFX sources busy. Forcing playback on first source.");
        sfxSources[0].clip = clip;
        sfxSources[0].volume = volume;
        sfxSources[0].Play();
    }

    private IEnumerator FadeInMusicCoroutine(AudioClip clip, float duration, bool loop)
    {
        musicSource.Stop();
        musicSource.clip = clip;
        musicSource.loop = loop;
        musicSource.volume = 0f;
        musicSource.Play();

        float elapsed = 0f;
        while (elapsed < duration)
        {
            musicSource.volume = Mathf.Lerp(0f, 1f, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        musicSource.volume = 1f;
    }

    private IEnumerator FadeOutMusicCoroutine(float duration)
    {
        float startVolume = musicSource.volume;
        float elapsed = 0f;
        while (elapsed < duration)
        {
            musicSource.volume = Mathf.Lerp(startVolume, 0f, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        musicSource.volume = 0f;
        musicSource.Stop();
    }

}
