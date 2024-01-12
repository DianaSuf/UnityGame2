using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeScin : MonoBehaviour
{
    public Sprite sprite1;
    public Sprite sprite2;
    public int access;
    public Button button1;
    public Button button2;
    public Button button3;
    private string ScinName = "scin";

    public void Awake()
    {
        UpdateScin();
    }

    private void UpdateScin()
    {
        access = PlayerPrefs.GetInt(ScinName);
        if (access == 0)
        {
            button1.image.sprite = sprite1;
            button2.image.sprite = sprite1;
            button3.image.sprite = sprite1;
        }
        else if (access == 1)
        {
            button1.image.sprite = sprite2;
        }
        else if (access == 2)
        {
            button2.image.sprite = sprite2;
        }
        else if (access == 3)
        {
            button3.image.sprite = sprite2;
        }
    }

    public void ChangeScin1()
    {
        access = PlayerPrefs.GetInt(ScinName);
        if (access == 0)
        {     
            PlayerPrefs.SetInt(ScinName, 1);
            UpdateScin();
        }
        else
        {
            PlayerPrefs.SetInt(ScinName, 0);
            UpdateScin();
        }
    }

    public void ChangeScin2()
    {
        access = PlayerPrefs.GetInt(ScinName);
        if (access == 0)
        {
            PlayerPrefs.SetInt(ScinName, 2);
            UpdateScin();
        }
        else
        {
            PlayerPrefs.SetInt(ScinName, 0);
            UpdateScin();
        }
    }

    public void ChangeScin3()
    {
        access = PlayerPrefs.GetInt(ScinName);
        if (access == 0)
        {
            PlayerPrefs.SetInt(ScinName, 3);
            UpdateScin();
        }
        else
        {
            PlayerPrefs.SetInt(ScinName, 0);
            UpdateScin();
        }
    }





}
