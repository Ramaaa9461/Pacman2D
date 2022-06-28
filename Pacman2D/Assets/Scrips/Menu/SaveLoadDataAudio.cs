using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SaveLoadDataAudio : MonoBehaviour
{
    const string musicPath = "Music";

    public UnityEvent<float> setPreloadVolume;

    private void Start()
    {
        if (PlayerPrefs.HasKey(musicPath))
        {
            setPreloadVolume.Invoke(PlayerPrefs.GetFloat(musicPath));
        }
        else
        {
            setPreloadVolume.Invoke(.5f);
        }
    }

    public void SaveNewVolume(float volume)
    {
        PlayerPrefs.SetFloat(musicPath, volume);
    }

}
