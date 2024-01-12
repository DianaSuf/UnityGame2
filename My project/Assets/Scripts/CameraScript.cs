using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Transform player;
    public int scin;
    public GameObject pers0;
    public GameObject pers1;
    public GameObject pers2;
    public GameObject pers3;

    void Start()
    {
        scin = PlayerPrefs.GetInt("scin");
        if (scin == 0)
        {
            pers0.SetActive(true);
        }
        if (scin == 1)
        {
            pers1.SetActive(true);
        }
        if (scin == 2)
        {
            pers2.SetActive(true);
        }
        if (scin == 3)
        {
            pers3.SetActive(true);
        }
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        Vector3 temp = transform.position;
        temp.x = player.position.x;
        temp.y = player.position.y;

        transform.position = temp;
    }
}
