using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] List<AudioSource> audioSources;

    public void changeVolumeMusic(float volume)
    {
        foreach (AudioSource AS in audioSources)
        {
            AS.volume = volume;
        }
    }
}
