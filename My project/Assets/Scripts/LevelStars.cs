using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LevelStars : MonoBehaviour
{
    public int level;
    public string nameLevel;
    public GameObject stars0;
    public GameObject stars1;
    public GameObject stars2;
    public GameObject stars3;

    public void Update()
    {
        level = PlayerPrefs.GetInt(nameLevel);
        if (level == 0)
        {
            stars0.gameObject.SetActive(true);
            stars1.gameObject.SetActive(false);
            stars2.gameObject.SetActive(false);
            stars3.gameObject.SetActive(false);
        }
        else if (level == 1)
        {
            stars1.gameObject.SetActive(true);
            stars0.gameObject.SetActive(false);
            stars2.gameObject.SetActive(false);
            stars3.gameObject.SetActive(false);
        }
        else if (level == 2)
        {
            stars2.gameObject.SetActive(true);
            stars1.gameObject.SetActive(false);
            stars0.gameObject.SetActive(false);
            stars3.gameObject.SetActive(false);
        }
        else if (level == 3)
        {
            stars3.gameObject.SetActive(true);
            stars1.gameObject.SetActive(false);
            stars2.gameObject.SetActive(false);
            stars0.gameObject.SetActive(false);
        }
    }
}