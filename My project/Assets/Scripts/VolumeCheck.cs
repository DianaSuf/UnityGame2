using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeCheck : MonoBehaviour
{
    public string volumeParameter = "MasterVolume";
    public AudioMixer mixer;
    public Toggle toggle;
    private float _volumeValue;

    public void ValueMusic()
    {
        if (toggle.isOn)
        {
            _volumeValue = PlayerPrefs.GetFloat(volumeParameter, 0.0f);
        }
        else
        {
            _volumeValue = -80.0f;
        }
        mixer.SetFloat(volumeParameter, _volumeValue);
    }
}
