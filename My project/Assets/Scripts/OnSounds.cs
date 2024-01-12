using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OnSounds : MonoBehaviour
{
    public string volumeParameter = "MasterVolume";
    public AudioMixer mixer;
    private float _volumeValue;

    public void OnSound()
    {
        _volumeValue = PlayerPrefs.GetFloat(volumeParameter, 0.0f);
        mixer.SetFloat(volumeParameter, _volumeValue);
    }
}
