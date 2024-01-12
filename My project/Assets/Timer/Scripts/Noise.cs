using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Noise : MonoBehaviour
{
    public Image NoiseScale;
    public static bool MaxScaleNoise;
    public GameObject Enemy;

    void Start()
    {

    }

    void Update()
    {
        //CheckSilence();
        if (TimeCounter.TimeRemaining > 0 && Progress.MaxCount != Progress.RealCount)
        {
            if (!Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.W) 
                || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
                && !Movement.trigIce)
                GetNoise();
            else if (Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.W)
                || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) ||
                Movement.trigIce)
                GetSilenceWithCondition();
            else GetSilence();

            if (NoiseScale.fillAmount == 1f)
            {
                MaxScaleNoise = true;
                NoiseScale.fillAmount = 0f;
            }
            else
            {
                MaxScaleNoise = false;
            }
        }

    }

    private void GetNoise()
    {
        NoiseScale.fillAmount = Mathf.Lerp(NoiseScale.fillAmount, 0.2f + NoiseScale.fillAmount, Time.deltaTime);
    }

    private void GetSilenceWithCondition()
    {
        NoiseScale.fillAmount = Mathf.Lerp(NoiseScale.fillAmount, NoiseScale.fillAmount - 0.05f, Time.deltaTime);
    }

    private void GetSilence()
    {
        NoiseScale.fillAmount = Mathf.Lerp(NoiseScale.fillAmount, NoiseScale.fillAmount - 0.1f, Time.deltaTime);
    }

    //private void CheckSilence()
    //{
    //    if (Enemy.activeInHierarchy)
    //    {
    //        Debug.Log("22");
    //    }
    //}
}
