using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeInit : MonoBehaviour
{
    public string volumeParameter = "MasterVolume";
    public AudioMixer mixer;

    void Start()
    {
        var volumeValue = PlayerPrefs.GetFloat(volumeParameter, 0.0f);
        mixer.SetFloat(volumeParameter, volumeValue);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
