using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LevelStars : MonoBehaviour
{
    public LevelIdentifier levelId;
    public List<GameObject> starsPanels = new();

    public void Start()
    {
        var stars = LevelManager.getLevelStars(levelId);
        starsPanels[stars].SetActive(true);
    }
}