using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopControl : MonoBehaviour
{
    public string ShopName;
    public int price, access;
    public GameObject block;
    public TextMeshProUGUI priceText;
    public GameObject union;
    public Button buy;
    public Button takeOff;

    public void Awake()
    {
        UpdateShop();
    }

    private void UpdateShop()
    {
        //PlayerPrefs.DeleteAll();
        access = PlayerPrefs.GetInt(ShopName + "Access");

        if (access == 1)
        {
            block.SetActive(false);
            priceText.gameObject.SetActive(false);
            union.SetActive(false);
            buy.gameObject.SetActive(false);
            takeOff.gameObject.SetActive(true);
        }
    }

    public void GetShop()
    {
        int snow = PlayerPrefs.GetInt("snow");
        if (access == 0 && snow >= price)
        {
            PlayerPrefs.SetInt(ShopName + "Access", 1);
            PlayerPrefs.SetInt("snow", snow - price);
            UpdateShop();
        }
    }
}
