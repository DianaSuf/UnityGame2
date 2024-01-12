using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulsation : MonoBehaviour
{
    public GameObject go; // Объект, размер которого будем менять (задается в инспекторе)
    private float timer = 2.0f;
    private Vector2 scale; // Переменная для текущего размера
    private Vector2 newscale; // Переменная для нового размера

    void Start()
    {
        scale = new Vector2(go.transform.localScale.x, go.transform.localScale.y); // Проверяем текущий размер
        newscale = scale;
    }

    void Update()
    {
        timer -= 1f;
        go.transform.localScale = Vector2.Lerp(go.transform.localScale, newscale, 1.5f * Time.deltaTime);
        if (timer >= 1.0f)
        {
            newscale = new Vector2(Random.Range(2.0f, 10.0f), Random.Range(2.0f, 10.0f)); // Задаем новый случайный размер
            timer = 2.0f;
        }   
    }
}
