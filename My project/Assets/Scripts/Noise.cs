using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Noise : MonoBehaviour
{
    public static UnityEvent OnNoise = new();

    public Image noiseImage;
    public float noiseCapacity = 3;
    private float _noiseAmount = 0;
    public float NoiseAmount
    {
        get
        {
            return _noiseAmount;
        }
        set
        {
            _noiseAmount = Mathf.Max(value, 0);
        }
    }

    [Header("Noise Modifiers")]
    public float defaultModifier = 1f;
    public float iceModifier = 0.5f;
    public float standModifier = -1.5f;

    private void Start()
    {

    }

    private void Update()
    {
        UpdateNoise();

        if (NoiseAmount >= noiseCapacity)
        {
            NoiseAmount -= noiseCapacity;
            OnNoise.Invoke();
        }

        noiseImage.fillAmount = NoiseAmount / noiseCapacity;
    }

    private void UpdateNoise()
    {
        float axisX = Input.GetAxisRaw("Horizontal");
        float axisY = Input.GetAxisRaw("Vertical");
        bool isMoving = Mathf.Abs(axisX) + Mathf.Abs(axisY) > 0;

        if (isMoving)
        {
            NoiseAmount += (Movement.isOnIce ? iceModifier : defaultModifier) * Time.deltaTime;
        }
        else
        {
            NoiseAmount += standModifier * Time.deltaTime;
        }
    }
}
