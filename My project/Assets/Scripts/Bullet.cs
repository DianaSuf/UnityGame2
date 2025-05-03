using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 10f;
    public float distance;
    public AudioClip hitSoundClip;

    private Vector2 target;

    void Start()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            var hitGO = new GameObject("Snowball hit sound");
            var audioSource = hitGO.AddComponent<AudioSource>();
            audioSource.clip = hitSoundClip;
            audioSource.Play();
            Destroy(hitGO, hitSoundClip.length);

            Destroy(collision.gameObject);
        }
    }
}   