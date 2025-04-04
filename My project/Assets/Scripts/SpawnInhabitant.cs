using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInhabitant : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject enemyIcon;
    public List<Vector2> spawnPositions = new();

    private void Start()
    {
        Enemy.OnDeath.AddListener((enemy) =>
        {
            if (Enemy.totalAlive <= 0)
                enemyIcon.SetActive(false);
        });

        Enemy.OnSpawn.AddListener((enemy) =>
        {
            enemyIcon.SetActive(true);
        });

        Noise.OnNoise.AddListener(() =>
        {
            if (TimeCounter.TimeRemaining <= 0 || Movement.isFinish || Movement.isEnemy) return;
            SpawnNearestEnemy();
        });

        Movement.OnEnterLight.AddListener(() =>
        {
            if (TimeCounter.TimeRemaining <= 0 || Movement.isFinish || Movement.isEnemy) return;
            SpawnNearestEnemy();
        });
    }

    private void SpawnNearestEnemy()
    {
        Vector2 nearestLocation = spawnPositions[0];

        spawnPositions.ForEach((position) =>
        {
            float a = Vector2.Distance(Movement.Instance.transform.position, nearestLocation);
            float b = Vector2.Distance(Movement.Instance.transform.position, position);
            if (b < a)
                nearestLocation = position;
        });

        Instantiate(enemyPrefab, nearestLocation, Quaternion.identity);
    }
}
