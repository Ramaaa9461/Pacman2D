using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIinteraction : MonoBehaviour
{
    public UnityEvent<float> changeMusicVolume;

    [SerializeField] Toggle toggle;
    [SerializeField] Slider slider;

    float volume;
    public void SetUIValues(float volume)
    {
        if (volume == 0)
        {
            toggle.isOn = false;
        }
        else
        {
            toggle.isOn = true;
            slider.value = volume;
        }
    }

    public void MusicActive(bool isActive)
    {
        if (isActive)
        {
            volume = 1;
        }
        else
        {
            volume = 0;
        }

        changeMusicVolume.Invoke(volume);
    }

    public void MusicVolume(float volume)
    {
        this.volume = volume;
        changeMusicVolume.Invoke(volume);
    }
}