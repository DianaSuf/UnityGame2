using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 10f;
    //public float liveTime;
    public float distance;
    public LayerMask whatIsSolid;
    //public static bool isDead = false;

    private Vector2 target;

    void Start()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            //if (hitInfo.collider.CompareTag("Enemy"))
            //{
            //    isDead = true;
            //    Debug.Log("fdf");
            //}
            Destroy(gameObject);
        }

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            Destroy(gameObject);
        }
    }
}