using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CountSnow : MonoBehaviour
{
    public TextMeshProUGUI snowAll;
    void Update()
    {
        int snow = PlayerPrefs.GetInt("snow");
        snowAll.text = string.Format("{0}", snow);
    }
}
