using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsAudio : MonoBehaviour
{
    // Usando referencias de:
    // https://www.youtube.com/watch?v=pbuJUaO-wpY&ab_channel=KapKoder

    public AudioMixer mixer;
    public Slider musicSlider, sfxSlider;

    const string MIXER_MUSIC = "MusicVolume";
    const string MIXER_SFX = "SfxVolume";

    public static OptionsAudio instance;

    

    private void Awake()
    {
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSfxVolume);


        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
                       
        }

        else
        {
            Destroy(gameObject);
        }

    }

    void SetMusicVolume(float value)
    {
        mixer.SetFloat(MIXER_MUSIC, Mathf.Log10(value) * 20);
    }

    void SetSfxVolume(float value)
    {
        mixer.SetFloat(MIXER_SFX, Mathf.Log10(value) * 20);
    }
           

}
