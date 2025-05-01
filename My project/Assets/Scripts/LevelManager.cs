using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public LevelIdentifier levelId;
    string levelName => "level" + levelId;

    public static LevelManager Instance = null;

    public void Awake()
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

    public static int getLevelStars(LevelIdentifier levelId)
    {
        return PlayerPrefs.GetInt("level" + levelId, 0);
    }

    public int getStars()
    {
        return PlayerPrefs.GetInt(levelName, 0);
    }

    public void saveStars(int stars)
    {
        if (stars > getStars())
        {
            PlayerPrefs.SetInt(levelName, stars);
        }
    }

    public void addSnow(int amount)
    {
        int snow = getSnow();
        PlayerPrefs.SetInt("snow", snow + amount);
    }

    public int getSnow()
    {
        return PlayerPrefs.GetInt("snow");
    }
}