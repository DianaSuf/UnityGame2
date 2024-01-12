using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoActiv : MonoBehaviour
{
    public GameObject block;
    public Button button;
    public string nameLevel;
    private int level;

    // Update is called once per frame
    void Update()
    {
        level = PlayerPrefs.GetInt(nameLevel);
        if (level == 0)
        {
            block.SetActive(true);
            button.interactable = false;
        }
        else
        {
            block.SetActive(false);
            button.interactable = true;
        }
    }
}
