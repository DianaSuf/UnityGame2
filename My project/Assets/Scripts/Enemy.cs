using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static bool isDead;
    float speed = 1f;
    Transform target;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
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
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
        if (PauseMenu.GameIsPause || TimeCounter.menuStars) 
        {
            speed = 0;
        }
        else
        {
            speed = 2f;
        }
        //if (Bullet.isDead)
        //{
        //    Destroy(gameObject);
        //}
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("its enemy!");
            Destroy(gameObject);
            isDead = true;
        }
    }
}
