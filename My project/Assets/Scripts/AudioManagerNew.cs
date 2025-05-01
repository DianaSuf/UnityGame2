using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType
{
    Master,
    Sound,
    Music
}

public enum EventType
{
    PresentPickup
}

public class AudioManagerNew : MonoBehaviour
{
    public List<Tuple<AudioClip, SoundType>> list;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
