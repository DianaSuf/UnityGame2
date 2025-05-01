using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource SFXSource;

    public AudioClip presentPickUpClip;
    public AudioClip footstepsClip;

    public static AudioManager Instance;
    public static bool Footsteps = false;
    private static AudioSource footstepsSource = null;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        UpdateFootstepsVolume();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void UpdateFootstepsVolume()
    {
        if (AudioManager.footstepsSource == null)
        {
            if (Movement.Instance.TryGetComponent(out AudioManager.footstepsSource))
            {
                AudioManager.footstepsSource.clip = footstepsClip;
                AudioManager.footstepsSource.loop = true;
                AudioManager.footstepsSource.Play();
            }
        }

        var footstepsSource = Movement.Instance.GetComponent<AudioSource>();
        footstepsSource.volume = Mathf.Lerp(footstepsSource.volume, Footsteps ? 1 : 0, 7 * Time.deltaTime);

        if (Time.timeScale == 0 )
            footstepsSource.volume = 0;
    }
}
