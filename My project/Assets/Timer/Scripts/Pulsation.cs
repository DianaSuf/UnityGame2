using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulsation : MonoBehaviour
{
    public GameObject go; // ������, ������ �������� ����� ������ (�������� � ����������)
    private float timer = 2.0f;
    private Vector2 scale; // ���������� ��� �������� �������
    private Vector2 newscale; // ���������� ��� ������ �������

    void Start()
    {
        scale = new Vector2(go.transform.localScale.x, go.transform.localScale.y); // ��������� ������� ������
        newscale = scale;
    }

    void Update()
    {
        timer -= 1f;
        go.transform.localScale = Vector2.Lerp(go.transform.localScale, newscale, 1.5f * Time.deltaTime);
        if (timer >= 1.0f)
        {
            newscale = new Vector2(Random.Range(2.0f, 10.0f), Random.Range(2.0f, 10.0f)); // ������ ����� ��������� ������
            timer = 2.0f;
        }   
    }
}
