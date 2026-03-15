using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SimpleAudioSettings : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;
    public AudioSource musicSource;
    public AudioSource[] sfxSources; 

    private const string MusicVolKey = "MusicVolume";
    private const string SFXVolKey = "SFXVolume";

    void Start()
    {
        float savedMusic = PlayerPrefs.GetFloat(MusicVolKey, 0.8f);
        float savedSFX = PlayerPrefs.GetFloat(SFXVolKey, 0.8f);

        musicSlider.value = savedMusic;
        sfxSlider.value = savedSFX;

        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);

        SetMusicVolume(savedMusic);
        SetSFXVolume(savedSFX);
    }

    public void SetMusicVolume(float value)
    {
        if (musicSource != null)
            musicSource.volume = value;
        PlayerPrefs.SetFloat(MusicVolKey, value);
    }

    public void SetSFXVolume(float value)
    {
        foreach (var src in sfxSources)
            if (src != null) src.volume = value;
        PlayerPrefs.SetFloat(SFXVolKey, value);
    }

    public void SaveAndGoBack()
    {
        PlayerPrefs.Save();
        SceneManager.LoadScene("Main Menu");
    }

    
}