using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnInhabitant : MonoBehaviour
{
    public GameObject spawnInhabitant;
    public GameObject pointOne;
    public GameObject pointTwo;
    public GameObject pointTree;
    public GameObject pointFour;
    public GameObject pointFive;
    private int countSpawn;
    public GameObject icon;
    private Dictionary<string, bool> spawnLight = new Dictionary<string, bool>()
    {
        {"Light", true},
        {"Light1", true}
    };

    void Update()
    {
        if (TimeCounter.TimeRemaining > 0 && !Movement.isFinish && !Movement.isEnemy)
        {
            if (Noise.MaxScaleNoise && (Movement.score <= (Movement.MaxCount / 4)))
            {
                Instantiate(spawnInhabitant, pointOne.transform.position, Quaternion.identity);
                countSpawn++;
            }
            if ((Noise.MaxScaleNoise  &&
                (Movement.score <= ((Movement.MaxCount / 4) * 2)) && Movement.score > (Movement.MaxCount / 4)))
            {
                Instantiate(spawnInhabitant, pointTwo.transform.position, Quaternion.identity);
                countSpawn++;
            }
            if ((Noise.MaxScaleNoise && (Movement.score <=
                ((Movement.MaxCount / 4) * 3)) && Movement.score > ((Movement.MaxCount / 4) * 2)))
            {
                Instantiate(spawnInhabitant, pointTree.transform.position, Quaternion.identity);
                countSpawn++;
            }
            if (Noise.MaxScaleNoise && Movement.score <= Movement.MaxCount && Movement.score > ((Movement.MaxCount / 4) * 3))
            {
                Instantiate(spawnInhabitant, pointFour.transform.position, Quaternion.identity);
                countSpawn++;
            }
            if (Noise.MaxScaleNoise && Movement.score <= Movement.MaxCount && Movement.score > ((Movement.MaxCount / 4) * 3.5))
            {
                Instantiate(spawnInhabitant, pointFive.transform.position, Quaternion.identity);
                countSpawn++;
            }
            if (Movement.isLight && spawnLight.ContainsKey(Movement.lightPrefab) && spawnLight[Movement.lightPrefab])
            {
                if (Movement.lightPrefab == "Light")
                {
                    Instantiate(spawnInhabitant, pointTwo.transform.position, Quaternion.identity);
                    countSpawn++;
                }
                else if (Movement.lightPrefab == "Light1")
                {
                    Instantiate(spawnInhabitant, pointTree.transform.position, Quaternion.identity);
                    countSpawn++;
                }
                else if (Movement.lightPrefab == "Light2")
                {
                    Instantiate(spawnInhabitant, pointFive.transform.position, Quaternion.identity);
                    countSpawn++;
                }
                else if (Movement.lightPrefab == "Light3")
                {
                    Instantiate(spawnInhabitant, pointFive.transform.position, Quaternion.identity);
                    countSpawn++;
                }
                spawnLight[Movement.lightPrefab] = false;
            }
        }
        if (Enemy.isDead)
        {
            countSpawn--;
            Enemy.isDead = false;   
        }

        if (countSpawn > 0)
        {
            icon.SetActive(true);
        }
        if (countSpawn < 0)
        {
            icon.SetActive(false);
        }
    }
}
