using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicControl : MonoBehaviour
{
    [SerializeField] List<AudioSource> audioSources;
    [SerializeField] Toggle toggle;
    [SerializeField] Slider slider;


    const string musicPath = "Music";

    private void Start()
    {
        if (PlayerPrefs.HasKey(musicPath))
        {
            foreach (AudioSource AS in audioSources)
            {
                AS.volume = PlayerPrefs.GetFloat(musicPath);

                if (AS.volume == 0)
                {
                    toggle.isOn = false;
                }
                else
                {
                    toggle.isOn = true;
                    slider.value = AS.volume;
                }
            }
        }
        else
        {
            foreach (AudioSource AS in audioSources)
            {
                AS.volume = 0.5f;

            }
        }
    }

    public void MusicActive(bool isActive)
    {

        foreach (AudioSource AS in audioSources)
        {
            if (isActive)
            {
                AS.volume = 1;
                PlayerPrefs.SetFloat(musicPath, 1);
            }
            else
            {
                AS.volume = 0;
                PlayerPrefs.SetFloat(musicPath, 0);
            }
            slider.value = AS.volume;
        }
    }
    public void MusicVolume(float volume)
    {
        foreach (AudioSource AS in audioSources)
        {
            AS.volume = volume;
            PlayerPrefs.SetFloat(musicPath, volume);
        }
    }

}


//https://www.free-stock-music.com/electronic-senses-absolom.html