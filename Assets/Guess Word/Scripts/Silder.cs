using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Silder : MonoBehaviour
{
    public Slider progressBar;
    public AudioSource audioSource;

    void Start()
    {
        progressBar.maxValue = audioSource.clip.length;
    }

    void Update()
    {
        progressBar.value = audioSource.time;
    }

    public void PlayMusic()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
    public void PauseMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
    }
}
