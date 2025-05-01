using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public static float totalAlive = 0;
    public static UnityEvent<Enemy> OnSpawn = new();
    public static UnityEvent<Enemy> OnDeath = new();
    
    private float speed = 1f;
    private Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        totalAlive += 1;
        OnSpawn.Invoke(this);
    }

    private void OnDestroy()
    {
        totalAlive -= 1;
        OnDeath.Invoke(this);
    }

    void Update()
    {
        if (target.position.x > transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        if (PauseMenu.GameIsPause) 
        {
            speed = 0;
        }
        else
        {
            speed = 2f;
        }
    }
}
