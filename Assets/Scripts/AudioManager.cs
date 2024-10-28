using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;
    public AudioMixer audioMixer;


    [SerializeField]private Slider musicSlider, sfxSlider, globalSlider;
    [SerializeField]private TMP_Text musicText, sfxText, globalText;

    private void Start()
    {
       audioMixer.SetFloat("Music",PlayerPrefs.GetFloat("MusicVolume", 1));
       audioMixer.SetFloat("SFX",PlayerPrefs.GetFloat("SfxVolume", 1));
       audioMixer.SetFloat("Global",PlayerPrefs.GetFloat("GlobalVolume", 1));
        playMusic();
    }

    public void playMusic()
    {
        musicSource.clip = musicSounds[Random.Range(0, musicSounds.Length)];
        musicSource.Play();
    }

    public void MusicSlider(float volume)
    {
         musicText.text = volume.ToString("0.0");
         PlayerPrefs.SetFloat("MusicVolume", volume);
         audioMixer.SetFloat("Music", volume);
    }
    
    public void SfxSlider(float volume)
    {
        sfxText.text = volume.ToString("0.0");
        PlayerPrefs.SetFloat("SfxVolume", volume);
        audioMixer.SetFloat("SFX", volume);
    }
    
    public void GlobalSlider(float volume)
    {
        globalText.text = volume.ToString("0.0");
        PlayerPrefs.SetFloat("GlobalVolume", volume);
        audioMixer.SetFloat("Global", volume);
    }
}