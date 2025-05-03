using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class Speed
{
    public LevelIdentifier levelId;
    [Range(0.5f, 3)]public float value;
}

public class Enemy : MonoBehaviour
{
    public static float totalAlive = 0;
    public static UnityEvent<Enemy> OnSpawn = new();
    public static UnityEvent<Enemy> OnDeath = new();
    
    private float speed = 1f;

    public List<Speed> speeds = new();

    private Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        totalAlive += 1;
        OnSpawn.Invoke(this);

        var data = speeds.FirstOrDefault((item) => item.levelId == LevelManager.Instance.levelId);
        Debug.Log(data);

        Debug.Log(data.value);
        speed = data.value;
    }

    private void OnDestroy()
    {
        totalAlive -= 1;
        OnDeath.Invoke(this);
    }

    void Update()
    {
        if (target.position.x > transform.position.x)
            transform.eulerAngles = new Vector3(0, 180, 0);
        else
            transform.eulerAngles = new Vector3(0, 0, 0);

        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
