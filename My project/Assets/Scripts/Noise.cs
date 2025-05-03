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
    [Range(-4, 4)] public float defaultModifier = 1f;
    [Range(-4, 4)] public float iceModifier = 0.5f;
    [Range(-4, 4)] public float crouchingModifier = -1f;
    [Range(-4, 4)] public float standModifier = -1.5f;

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
            var modifier = defaultModifier;
            if (Movement.Instance.isOnIce) modifier = iceModifier;
            if (Movement.Instance.isCrouching) modifier = crouchingModifier;

            NoiseAmount += modifier * Time.deltaTime;
        }
        else
        {
            NoiseAmount += standModifier * Time.deltaTime;
        }
    }
}
