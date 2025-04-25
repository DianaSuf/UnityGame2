using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TimeCounter : MonoBehaviour
{
    public float maxTime;
    private float timeRemaining;
    public TextMeshProUGUI timeUI;
    public static UnityEvent OnTimeUp = new();

    void Start()
    {
        timeRemaining = maxTime;
    }

    void Update()
    {
        UpdateTime();
    }

    void UpdateTime()
    {
        if (timeRemaining <= 0) return;

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
            OnTimeUp.Invoke();
        }

        float minutes = Mathf.FloorToInt(timeRemaining / 60);
        float seconds = Mathf.FloorToInt(timeRemaining - minutes * 60f);

        timeUI.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
