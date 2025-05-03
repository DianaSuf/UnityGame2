using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoActiv : MonoBehaviour
{
    public GameObject block;
    public Button button;
    public LevelIdentifier levelId;

    void Start()
    {
        if (LevelManager.getLevelStars(levelId) > 0)
        {
            block.SetActive(false);
            button.interactable = true;
        }
        else
        {
            block.SetActive(true);
            button.interactable = false;
        }
    }
}
