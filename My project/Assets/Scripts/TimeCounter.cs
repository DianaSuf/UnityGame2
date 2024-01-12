using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class TimeCounter : MonoBehaviour
{
    public float MaxTime;
    public static float TimeRemaining;
    public TextMeshProUGUI time;
    public GameObject Stars3;
    public GameObject Stars2;
    public GameObject Stars1;
    public GameObject Stars0;
    public static int snow;
    public static bool snowslv;
    public static bool menuStars = false;
    private int stars;
    [SerializeField] TextMeshProUGUI scoreText;
    public string levelName;
    public int colGift1;
    public int colGift2;
    public int colGift3;

    void Start()
    {
        TimeRemaining = MaxTime;
        snowslv = true;
        stars = PlayerPrefs.GetInt(levelName);
    }

    void Update()
    {
        //PlayerPrefs.DeleteAll();
        float minutes, seconds;
        if (TimeRemaining > 0 && Movement.score <= Movement.MaxCount)
        {
            minutes = Mathf.FloorToInt(TimeRemaining / 60);
            seconds = Mathf.FloorToInt(TimeRemaining - minutes * 60f);
            time.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            TimeRemaining -= Time.deltaTime;
        }
        if ((TimeRemaining < 0 && Movement.score < colGift1 && snowslv) || 
            (TimeRemaining > 0 && Movement.score < colGift1 && snowslv && Movement.isFinish) ||
            (TimeRemaining > 0 && Movement.score < colGift1 && snowslv && Movement.isEnemy))
        {
            
            Stars0.SetActive(true);
            Time.timeScale = 0f;
            snow = PlayerPrefs.GetInt("snow");
            PlayerPrefs.SetInt("snow", snow + 0);
            snow = PlayerPrefs.GetInt("snow");
            snowslv = false;
            menuStars = true;
            if (stars <= 0) PlayerPrefs.SetInt(levelName, 0);
        }
        if ((TimeRemaining < 0 && colGift1 <= Movement.score && Movement.score < colGift2 && snowslv) 
            || (TimeRemaining > 0 && colGift1 <= Movement.score && Movement.score < colGift2 && snowslv && Movement.isFinish)
            || (TimeRemaining > 0 && colGift1 <= Movement.score && Movement.score < colGift2 && snowslv && Movement.isEnemy))
        {
            Stars1.SetActive(true);
            Time.timeScale = 0f;
            snow = PlayerPrefs.GetInt("snow");
            PlayerPrefs.SetInt("snow", snow + 5);
            snow = PlayerPrefs.GetInt("snow");
            snowslv = false;
            menuStars = true;
            if (stars <= 1) PlayerPrefs.SetInt(levelName, 1);
        }
        if ((TimeRemaining < 0 && colGift2 <= Movement.score && Movement.score < colGift3 && snowslv) 
            || (TimeRemaining > 0 && colGift2 <= Movement.score && Movement.score < colGift3 && snowslv && Movement.isFinish)
            || (TimeRemaining > 0 && colGift2 <= Movement.score && Movement.score < colGift3 && snowslv && Movement.isEnemy))
        {
            Stars2.SetActive(true);
            Time.timeScale = 0f;
            snow = PlayerPrefs.GetInt("snow");
            PlayerPrefs.SetInt("snow", snow + 10);
            snow = PlayerPrefs.GetInt("snow");      
            snowslv = false;
            menuStars = true;
            if (stars <= 2) PlayerPrefs.SetInt(levelName, 2);
        }
        if ((TimeRemaining < 0 && Movement.score == colGift3 && snowslv) || 
            (TimeRemaining > 0 && Movement.score == colGift3 && snowslv && Movement.isFinish) ||
            (TimeRemaining > 0 && Movement.score == colGift3 && snowslv && Movement.isEnemy))
        {
            Stars3.SetActive(true);
            Time.timeScale = 0f;
            snow = PlayerPrefs.GetInt("snow");
            PlayerPrefs.SetInt("snow", snow + 15);
            snow = PlayerPrefs.GetInt("snow");
            snowslv = false;
            menuStars = true;
            if (stars <= 3) PlayerPrefs.SetInt(levelName, 3);
        }
    }
}
