using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class itemInfo : MonoBehaviour
{


    public int itemID;
    public TextMeshProUGUI PriceTxt;
    public TextMeshProUGUI QuantityTxt;
    public GameObject ShopManager;

    void Update()
    {
        PriceTxt.text = "Price: $" + ShopManager.GetComponent<ShopManagerScript>().shopItems[2,itemID].ToString();
        QuantityTxt.text = ShopManager.GetComponent<ShopManagerScript>().shopItems[3,itemID].ToString();
    }
}
